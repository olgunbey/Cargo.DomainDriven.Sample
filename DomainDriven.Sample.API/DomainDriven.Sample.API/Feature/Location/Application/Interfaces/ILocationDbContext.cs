using DomainDriven.Sample.API.Common;
using DomainDriven.Sample.API.Feature.Location.Domain.Aggregates;
using DomainDriven.Sample.API.Feature.Location.Domain.ReadModels;
using Microsoft.EntityFrameworkCore;

namespace DomainDriven.Sample.API.Feature.Location.Application.Interfaces
{
    public interface ILocationDbContext : IBaseDbContext
    {
        public DbSet<City> City { get; set; }
        public DbSet<CustomerOrderTargetLocation> CustomerOrderTargetLocation { get; set; }
        public DbSet<CustomerOrderTargetLocationReadModel> CustomerOrderTargetLocationReadModel { get; set; }
    }
}
