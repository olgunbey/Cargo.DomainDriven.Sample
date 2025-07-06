using Microsoft.EntityFrameworkCore;

namespace DomainDriven.Sample.API.Database
{
    public class CargoDbContext : DbContext, IApplicationDbContext
    {
        public CargoDbContext(DbContextOptions<CargoDbContext> dbContextOptions) : base(dbContextOptions)
        {
        }
        DbSet<TEntity> IApplicationDbContext.GetEntity<TEntity>()
        {
            return Set<TEntity>();
        }
    }
}
