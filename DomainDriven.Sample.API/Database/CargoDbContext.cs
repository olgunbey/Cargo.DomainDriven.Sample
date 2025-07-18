using DomainDriven.Sample.API.CargoManagement.Application.IRepositories;
using DomainDriven.Sample.API.CargoManagement.Domain.Aggregates;
using DomainDriven.Sample.API.Common;
using DomainDriven.Sample.API.Location.Application.IRepositories;
using DomainDriven.Sample.API.Location.Domain.Aggregates;
using DomainDriven.Sample.API.Order.Application.IRepositories;
using DomainDriven.Sample.API.Order.Application.ReadModels;
using DomainDriven.Sample.API.Order.Domain.Aggregates;
using Microsoft.EntityFrameworkCore;

namespace DomainDriven.Sample.API.Database
{
    public class CargoDbContext : DbContext, ICargoManagementDbContext, ILocationDbContext, IOrderDbContext
    {
        public CargoDbContext(DbContextOptions<CargoDbContext> dbContextOptions) : base(dbContextOptions)
        {
        }
        public DbSet<City> City { get; set; }
        public DbSet<CargoReadModel> CargoReadModel { get; set; }
        public DbSet<Company> Company { get; set; }
        public DbSet<CargoDetailInformation> CargoDetailInformation { get; set; }
        public DbSet<Order.Domain.Aggregates.Order> Order { get; set; }
        public DbSet<OrderCustomerReadModel> CustomerReadModel { get; set; }
        public DbSet<OrderChooseEmployee> OrderChooseEmployee { get; set; }

        DbSet<TEntity> IBaseDbContext.GetDbSet<TEntity>()
        {
            return Set<TEntity>();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<CargoReadModel>().OwnsOne(y => y.Status);

            modelBuilder.Entity<Order.Domain.Aggregates.Order>().OwnsOne(y => y.TargetLocation);

            modelBuilder.Entity<OrderCustomerReadModel>().OwnsOne(y => y.TargetLocationModel);


            modelBuilder.Entity<OrderCustomerReadModel>().OwnsOne(y => y.CustomerReadModel);
            base.OnModelCreating(modelBuilder);
        }
    }
}
