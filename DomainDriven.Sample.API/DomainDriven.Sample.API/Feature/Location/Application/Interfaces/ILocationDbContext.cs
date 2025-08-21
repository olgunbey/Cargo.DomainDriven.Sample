using DomainDriven.Sample.API.Common;
using DomainDriven.Sample.API.Feature.Location.Domain.Aggregates;
using Microsoft.EntityFrameworkCore;

namespace DomainDriven.Sample.API.Feature.Location.Application.Interfaces
{
    public interface ILocationDbContext : IBaseDbContext
    {
        public DbSet<City> City { get; set; }
        public DbSet<CustomerOrderTargetLocation> CustomerOrderTargetLocation { get; set; }
    }
}
