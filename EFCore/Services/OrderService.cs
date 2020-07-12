using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFCore.Contracts;
using EFCore.Models;
using EFCore.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EFCore.Services
{
	public class OrderService : IOrderService
	{
		private readonly IEFService<Order> orders;
		private readonly IEFService<Product> products;
		private readonly IEFService<Client> clients;

		public OrderService(IEFService<Order> orders, IEFService<Product> products, IEFService<Client> clients)
		{
			this.orders = orders;
			this.products = products;
			this.clients = clients;
		}

		public async Task<OrderDTO> Add(OrderDTO data)
		{
			var order = new Order
			{
				ProductCount = data.Count,
				ProductId = data.ProductId,
				ClientId = data.ClientId
			};
			order = await orders.Add(order);
			return (await GetAsync(order.OrderId)).FirstOrDefault();
		}

		public async Task<OrderDTO> Delete(OrderDTO data)
		{
			var order = await orders.GetAll().FirstOrDefaultAsync(x => x.OrderId == data.OrderId);
			if (order != null)
			{
				order.ProductCount = data.Count;
				order.ProductId = data.ProductId;
				order.ClientId = data.ClientId;
				order = await orders.Delete(order);
			}
			return (await GetAsync(data.OrderId)).FirstOrDefault();
		}

		public async Task<List<OrderDTO>> GetOrdersAsync(int orderid)
		{
			return await GetAsync(orderid);
		}

		public async Task<OrderDTO> Update(OrderDTO data)
		{
			var order = await orders.GetAll().FirstOrDefaultAsync(x => x.OrderId == data.OrderId);
			if (order != null)
			{
				order.ProductCount = data.Count;
				order.ProductId = data.ProductId;
				order.ClientId = data.ClientId;
				order = await orders.Update(order);
			}
			return (await GetAsync(data.OrderId)).FirstOrDefault();
		}

		private async Task<List<OrderDTO>> GetAsync(int orderid)
		{
		//multiple db context in single query. need to fix this issue.
			var query = from order in await orders.GetAll()
						join product in await products.GetAll() on order.ProductId equals product.ProductId
						join client in await clients.GetAll() on order.ClientId equals client.ClientId
						select new OrderDTO
						{
							Client = client.ClientName,
							Count = order.ProductCount,
							Product  = product.ProductName,
							Amount = product.Amount,
							Total = order.ProductCount*(product.Amount),
							OrderId = order.OrderId,
							ProductId = product.ProductId,
							ClientId = client.ClientId
						};

			if (orderid > 0)
				return query.Where(x => x.OrderId == orderid).ToList();
			else
				return query.ToList();
		}
	}
}
