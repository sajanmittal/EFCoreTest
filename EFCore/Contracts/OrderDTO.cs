namespace EFCore.Contracts
{
	public class OrderDTO
	{
		public string Client { get; set; }

		public int Count { get; set; }

		public string Product { get; set; }

		public decimal Amount { get; set; }

		public decimal Total { get; set; }

		public int OrderId { get; set; }

		public int ClientId { get; set; }

		public int ProductId { get; set; }
	}
}