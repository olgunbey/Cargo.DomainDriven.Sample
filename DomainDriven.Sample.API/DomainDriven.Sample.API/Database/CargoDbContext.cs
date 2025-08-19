using DomainDriven.Sample.API.Common;
using DomainDriven.Sample.API.Feature.Cargo.Application.Interfaces;
using DomainDriven.Sample.API.Feature.Cargo.Domain.Aggregates;
using DomainDriven.Sample.API.Feature.Cargo.Domain.ReadModel;
using DomainDriven.Sample.API.Feature.Customer.Domain.Aggregates;
using DomainDriven.Sample.API.Feature.Customer.Domain.ReadModels;
using DomainDriven.Sample.API.Feature.Customer.Infrastructure.Persistence;
using DomainDriven.Sample.API.Feature.IdentityServer.Application.Interfaces;
using DomainDriven.Sample.API.Feature.IdentityServer.Domain.Aggregates;
using DomainDriven.Sample.API.Feature.IdentityServer.Domain.ReadModel;
using DomainDriven.Sample.API.Feature.Location.Application.Interfaces;
using DomainDriven.Sample.API.Feature.Location.Domain.Aggregates;
using DomainDriven.Sample.API.Feature.Location.Domain.ReadModel;
using DomainDriven.Sample.API.Feature.Order.Application.Interfaces;
using DomainDriven.Sample.API.Feature.Order.Domain.Aggregates;
using DomainDriven.Sample.API.Feature.Order.Domain.ReadModel;
using DomainDriven.Sample.API.Feature.Product.Application.Interfaces;
using DomainDriven.Sample.API.Feature.Product.Domain.Aggregates;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ServiceStack;
using System.Reflection;

namespace DomainDriven.Sample.API.Database
{
    public class CargoDbContext(DbContextOptions<CargoDbContext> dbContextOptions, IMediator mediator) : DbContext(dbContextOptions), ICargoDbContext, ILocationDbContext, IOrderDbContext, IProductDbContext, ICustomerDbContext, IIdentityServerDbContext
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
        public DbSet<CargoInformation> CargoInformation { get; set; }
        public DbSet<UserInformation> UserInformation { get; set; }
        public DbSet<ClientCredential> ClientCredential { get; set; }
        public DbSet<CustomerReadModel> CustomerReadModel { get ; set ; }

        public DbSet<TEntity> GetDbSet<TEntity>() where TEntity : class
        {
            return Set<TEntity>();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(assembly: Assembly.GetExecutingAssembly());
        }
        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var domainEvents = ChangeTracker.Entries<AggregateRoot>()
                .SelectMany(e => e.Entity.Notifications)
                .ToList();


            foreach (var domainEvent in domainEvents)
            {
                await mediator.Publish(domainEvent, cancellationToken);
            }

            ChangeTracker.Entries<AggregateRoot>().ToList(); // hangi entity'ler üzerinnde state değiştirildi...

            foreach (var entry in ChangeTracker.Entries<AggregateRoot>())
            {
                entry.Entity.ClearDomainEvents();
            }
            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}
