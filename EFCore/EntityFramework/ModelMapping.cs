using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCore.EntityFramework
{
	public class ModelMapping<TEntity> : IEntityTypeConfiguration<TEntity> where TEntity : class
	{
		public virtual void Configure(EntityTypeBuilder<TEntity> builder)
		{
		}
	}
}