using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace EFCore.EntityFramework.Interfaces
{
	public interface IApplicationDbContext : IDisposable
	{
		DbSet<TEntity> Set<TEntity>() where TEntity : class;

		EntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;

		DbContext Context { get; }

		Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken));
	}
}