using DomainDriven.Sample.API.Common;
using DomainDriven.Sample.API.Location.Domain.Aggregates;
using DomainDriven.Sample.API.Location.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DomainDriven.Sample.API.Location.Application.IRepositories
{
    public interface ILocationDbContext : IBaseDbContext
    {
        public DbSet<City> City { get; set; }
        public DbSet<District> District { get; set; }
    }
}
