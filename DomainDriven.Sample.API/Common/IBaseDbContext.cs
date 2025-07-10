using Microsoft.EntityFrameworkCore;

namespace DomainDriven.Sample.API.Common
{
    public interface IBaseDbContext
    {
        public DbSet<TEntity> GetDbSet<TEntity>() where TEntity : class, IEntity, new();
        public Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
