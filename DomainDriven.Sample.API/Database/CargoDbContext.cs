using DomainDriven.Sample.API.Location.Domain.Aggregates;
using DomainDriven.Sample.API.Location.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DomainDriven.Sample.API.Database
{
    public class CargoDbContext : DbContext, IApplicationDbContext
    {
        public DbSet<City> City { get; set; }
        public DbSet<District> District { get; set; }
        public CargoDbContext(DbContextOptions<CargoDbContext> dbContextOptions) : base(dbContextOptions)
        {
        }
        DbSet<TEntity> IApplicationDbContext.GetEntity<TEntity>()
        {
            return Set<TEntity>();
        }
    }
}
