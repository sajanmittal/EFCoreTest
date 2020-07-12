using System.Threading.Tasks;
using EFCore.Contracts;
using EFCore.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EFCore.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class OrderController : ControllerBase
	{

		private IOrderService orderService;

		public OrderController(IOrderService orderService)
		{
			this.orderService = orderService;
		}

		[HttpGet("Get")]
		public async Task<IActionResult> Get(int? orderId)
		{
			return Ok(await orderService.GetOrdersAsync(orderId ?? 0));
		}

		[HttpPost("Update")]
		public async Task<IActionResult> Update([FromBody]OrderDTO order)
		{
			return Ok(await orderService.Update(order));
		}

		[HttpPost("Delete")]
		public async Task<IActionResult> Delete([FromBody]OrderDTO order)
		{
			return Ok(await orderService.Delete(order));
		}

		[HttpPost("Add")]
		public async Task<IActionResult> Add([FromBody]OrderDTO order)
		{
			return Ok(await orderService.Add(order));
		}
	}
}
