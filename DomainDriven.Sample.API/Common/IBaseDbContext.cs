using Microsoft.EntityFrameworkCore;

namespace DomainDriven.Sample.API.Common
{
    public interface IBaseDbContext
    {
        public DbSet<TEntity> GetDbSet<TEntity>() where TEntity : class;
        public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);


    }
}
