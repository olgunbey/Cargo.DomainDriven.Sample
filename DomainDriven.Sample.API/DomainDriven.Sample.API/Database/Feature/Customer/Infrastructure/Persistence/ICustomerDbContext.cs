using DomainDriven.Sample.API.Common;
using DomainDriven.Sample.API.Feature.Customer.Domain.Aggregates;
using Microsoft.EntityFrameworkCore;

namespace DomainDriven.Sample.API.Feature.Customer.Infrastructure.Persistence
{
    public interface ICustomerDbContext : IBaseDbContext
    {
        public DbSet<UserCredential> UserCredential { get; set; }
        public DbSet<UserInformation> UserInformation { get; set; }
    }
}
