using DomainDriven.Sample.API.Common;
using DomainDriven.Sample.API.Feature.Location.Domain.Aggregates;
using DomainDriven.Sample.API.Feature.Location.Domain.ReadModel;
using Microsoft.EntityFrameworkCore;

namespace DomainDriven.Sample.API.Feature.Location.Application.Interfaces
{
    public interface ILocationDbContext : IBaseDbContext
    {
        public DbSet<City> City { get; set; }
        public DbSet<CityReadModel> CityReadModel { get; set; }
        public DbSet<DistrictReadModel> DistrictReadModel { get; set; }
    }
}
