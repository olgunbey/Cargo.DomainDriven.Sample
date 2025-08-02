using DomainDriven.Sample.API.Common;
using DomainDriven.Sample.API.Feature.Cargo.Domain.Aggregates;
using DomainDriven.Sample.API.Feature.Cargo.Domain.ReadModel;
using Microsoft.EntityFrameworkCore;

namespace DomainDriven.Sample.API.Feature.Cargo.Application.Interfaces
{
    public interface ICargoDbContext : IBaseDbContext
    {
        public DbSet<Company> Company { get; set; }
        public DbSet<CargoInformation> CargoInformation { get; set; }
        public DbSet<CargoProductReadModel> CargoProductReadModel { get; set; }
    }
}
