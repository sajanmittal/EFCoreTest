using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EFCore.EntityFramework;

namespace EFCore.Models
{
	[Table(nameof(Product), Schema = "dbo")]
	public class Product
	{
		[Key]
		public int ProductId { get; set; }

		public string ProductName { get; set; }

		public decimal Amount { get; set; }
	}

	public class ProductMapping : ModelMapping<Product>
	{ }
}