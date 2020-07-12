using System.Collections.Generic;
using System.Threading.Tasks;
using EFCore.Contracts;

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