using System.Collections.Generic;
using System.Threading.Tasks;

namespace EFCore.Services.Interfaces
{
	public interface IEFService<T> where T : class
	{
		Task<List<T>> GetAll();

		Task<T> Add(T data);

		Task<T> Update(T data);

		Task<T> Delete(T data);
	}
}