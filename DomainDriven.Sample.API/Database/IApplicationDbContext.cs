using DomainDriven.Sample.API.Common;
using Microsoft.EntityFrameworkCore;

namespace DomainDriven.Sample.API.Database
{
    public interface IApplicationDbContext
    {
        public DbSet<TEntity> GetEntity<TEntity>() where TEntity : class, IEntity, new();
        public Task<int> SaveChangesAsync(CancellationToken cancellationToken);

    }
}
