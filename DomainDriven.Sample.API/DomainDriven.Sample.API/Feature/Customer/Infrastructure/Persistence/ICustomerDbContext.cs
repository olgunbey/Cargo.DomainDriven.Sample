using DomainDriven.Sample.API.Common;
using DomainDriven.Sample.API.Feature.Customer.Domain.Aggregates;
using DomainDriven.Sample.API.Feature.Customer.Domain.ReadModels;
using Microsoft.EntityFrameworkCore;

namespace DomainDriven.Sample.API.Feature.Customer.Infrastructure.Persistence
{
    public interface ICustomerDbContext : IBaseDbContext
    {
        public DbSet<UserInformation> UserInformation { get; set; }
        public DbSet<CustomerReadModel> CustomerReadModel { get; set; }
    }
}
