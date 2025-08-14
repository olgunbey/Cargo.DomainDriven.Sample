using DomainDriven.Sample.API.Feature.Cargo.Application.Interfaces;
using DomainDriven.Sample.API.Feature.Cargo.Domain.Aggregates;
using DomainDriven.Sample.API.Feature.Cargo.Domain.ReadModel;
using DomainDriven.Sample.API.Feature.Customer.Domain.Aggregates;
using DomainDriven.Sample.API.Feature.Customer.Infrastructure.Persistence;
using DomainDriven.Sample.API.Feature.Location.Application.Interfaces;
using DomainDriven.Sample.API.Feature.Location.Domain.Aggregates;
using DomainDriven.Sample.API.Feature.Location.Domain.ReadModel;
using DomainDriven.Sample.API.Feature.Order.Application.Interfaces;
using DomainDriven.Sample.API.Feature.Order.Domain.Aggregates;
using DomainDriven.Sample.API.Feature.Order.Domain.ReadModel;
using DomainDriven.Sample.API.Feature.Product.Application.Interfaces;
using DomainDriven.Sample.API.Feature.Product.Domain.Aggregates;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace DomainDriven.Sample.API.Database
{
    public class CargoDbContext(DbContextOptions<CargoDbContext> dbContextOptions) : DbContext(dbContextOptions), ICargoDbContext, ILocationDbContext, IOrderDbContext, IProductDbContext, ICustomerDbContext
    {
        public DbSet<Company> Company { get; set; }
        public DbSet<CargoProductReadModel> CargoProductReadModel { get; set; }
        public DbSet<City> City { get; set; }
        public DbSet<OrderProductReadModel> OrderProductRealModel { get; set; }
        public DbSet<OrderInformation> OrderInformation { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<CityReadModel> CityReadModel { get; set; }
        public DbSet<DistrictReadModel> DistrictReadModel { get; set; }
        public DbSet<CargoInformation> CargoInformation { get ; set ; }
        public DbSet<UserCredential> UserCredential { get ; set ; }
        public DbSet<UserInformation> UserInformation { get ; set ; }

        public DbSet<TEntity> GetDbSet<TEntity>() where TEntity : class
        {
            return Set<TEntity>();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(assembly: Assembly.GetExecutingAssembly());
        }
    }
}
