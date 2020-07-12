using System.Collections.Generic;
using System.Threading.Tasks;
using EFCore.Contracts;
using EFCore.Models;

namespace EFCore.Services.Interfaces
{
	public interface IOrderService
	{
		Task<List<OrderDTO>> GetOrdersAsync(int orderid);

		Task<OrderDTO> Add(OrderDTO data);

		Task<OrderDTO> Update(OrderDTO data);

		Task<OrderDTO> Delete(OrderDTO data);
	}
}
