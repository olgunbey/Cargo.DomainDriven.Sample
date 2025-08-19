using DomainDriven.Sample.API.Common;
using DomainDriven.Sample.API.Feature.IdentityServer.Domain.Aggregates;
using Microsoft.EntityFrameworkCore;

namespace DomainDriven.Sample.API.Feature.IdentityServer.Application.Interfaces
{
    public interface IIdentityServerDbContext : IBaseDbContext
    {
        public DbSet<ClientCredential> ClientCredential { get; set; }
        public DbSet<UserCredential> UserCredential { get; set; }

    }
}
