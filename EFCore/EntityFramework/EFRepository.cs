using System;
using System.Linq;
using System.Threading.Tasks;
using EFCore.EntityFramework.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace EFCore.EntityFramework
{
	public class EFRepository<TEntity> : IEFRepository<TEntity> where TEntity : class
	{
		private readonly IApplicationDbContext appDbContext;

		private readonly DbSet<TEntity> dbSet;

		public EFRepository(IApplicationDbContext appDbContext)
		{
			this.appDbContext = appDbContext;
			dbSet = appDbContext.Set<TEntity>();
		}

		public async Task<TEntity> AddAsync(TEntity entity)
		{
			return await SaveAsync(entity, EntityState.Added);
		}

		public async Task<TEntity> DeleteAsync(TEntity entity)
		{
			return await SaveAsync(entity, EntityState.Deleted);
		}

		public IQueryable<TEntity> GetAll()
		{
			return dbSet;
		}

		public async Task<TEntity> UpdateAsync(TEntity entity)
		{
			return await SaveAsync(entity, EntityState.Modified);
		}

		private async Task<TEntity> SaveAsync(TEntity entity, EntityState action)
		{
			EntityEntry<TEntity> dbEntityEntry = null;
			try
			{
				dbEntityEntry = appDbContext.Entry(entity);
				if (dbEntityEntry.State != EntityState.Detached)
					dbEntityEntry.State = action;
				else
				{
					switch (action)
					{
						case EntityState.Added:
							entity = (await dbSet.AddAsync(entity)).Entity;
							break;

						case EntityState.Modified:
							entity = dbSet.Update(entity).Entity;
							break;

						case EntityState.Deleted:
							dbSet.Attach(entity);
							entity = dbSet.Remove(entity).Entity;
							break;
					}
				}

				await appDbContext.SaveChangesAsync();
			}
			catch (Exception ex)
			{
				if (dbEntityEntry != null)
					dbEntityEntry.State = EntityState.Detached;

				throw ex;
			}

			return entity;
		}
	}
}