using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EFCore.EntityFramework;

namespace EFCore.Models
{
	[Table(nameof(Client), Schema = "dbo")]
	public class Client
	{
		[Key]
		public int ClientId { get; set; }

		public string ClientName { get; set; }
	}

	public class ClientMapping : ModelMapping<Client>
	{
		
	}
}