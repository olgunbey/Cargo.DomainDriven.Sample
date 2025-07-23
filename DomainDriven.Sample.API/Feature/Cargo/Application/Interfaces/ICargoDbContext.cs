using DomainDriven.Sample.API.Common;
using DomainDriven.Sample.API.Feature.Cargo.Domain.Aggregates;
using DomainDriven.Sample.API.Feature.Order.Domain.Aggregates;
using Microsoft.EntityFrameworkCore;

namespace DomainDriven.Sample.API.Feature.Cargo.Application.Interfaces
{
    public interface ICargoDbContext : IBaseDbContext
    {
        public DbSet<OrderInformation> OrderInformation { get; set; }
        public DbSet<Company> Company { get; set; }
    }
}
