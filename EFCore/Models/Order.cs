using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EFCore.EntityFramework;

namespace EFCore.Models
{
	[Table(nameof(Order), Schema = "dbo")]
	public class Order
	{
		[Key]
		public int OrderId { get; set; }

		public int ClientId { get; set; }

		public int ProductCount { get; set; }

		public int ProductId { get; set; }
	}

	public class OrderMapping : ModelMapping<Order>
	{
	}
}