using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFCore.EntityFramework.Interfaces;
using EFCore.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EFCore.Services
{
	public class EFService<T> : IEFService<T> where T : class
	{
		private readonly IEFRepository<T> repository;
		
		public EFService(IEFRepository<T> repository)
		{
			this.repository = repository;
		}

		public async Task<T> Add(T data)
		{
			return await repository.AddAsync(data);
		}

		public async Task<T> Delete(T data)
		{
			return await repository.DeleteAsync(data);
		}

		public async Task<List<T>> GetAll()
		{
			return await repository.GetAll().ToListAsync();
		}

		public async Task<T> Update(T data)
		{
			return await repository.UpdateAsync(data);
		}
	}
}
