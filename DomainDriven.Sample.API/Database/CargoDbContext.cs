using DomainDriven.Sample.API.CargoManagement.Application.IRepositories;
using DomainDriven.Sample.API.CargoManagement.Domain.Aggregates;
using DomainDriven.Sample.API.Common;
using DomainDriven.Sample.API.Location.Application.IRepositories;
using DomainDriven.Sample.API.Location.Domain.Aggregates;
using DomainDriven.Sample.API.Location.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DomainDriven.Sample.API.Database
{
    public class CargoDbContext : DbContext, ICargoManagementDbContext, ILocationDbContext
    {
        public CargoDbContext(DbContextOptions<CargoDbContext> dbContextOptions) : base(dbContextOptions)
        {
        }
        public DbSet<City> City { get; set; }
        public DbSet<District> District { get; set; }
        public DbSet<CargoReadModel> CargoReadModel { get; set; }
        public DbSet<Company> Company { get; set; }

        DbSet<TEntity> IBaseDbContext.GetDbSet<TEntity>()
        {
            throw new NotImplementedException();
        }
    }
}
