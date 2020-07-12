using System.Linq;
using System.Threading.Tasks;

namespace EFCore.EntityFramework.Interfaces
{
	public interface IEFRepository<TEntity> where TEntity : class
	{
		IQueryable<TEntity> GetAll();

		Task<TEntity> AddAsync(TEntity entity);

		Task<TEntity> UpdateAsync(TEntity entity);

		Task<TEntity> DeleteAsync(TEntity entity);
	}
}