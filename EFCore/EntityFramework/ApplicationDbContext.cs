using System.Reflection;
using EFCore.EntityFramework.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EFCore.EntityFramework
{
	public class ApplicationDbContext : DbContext, IApplicationDbContext
	{
		public ApplicationDbContext(DbContextOptions options):base(options)
		{

		}

		public DbContext Context => this;


		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
			modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
		}

	}
}