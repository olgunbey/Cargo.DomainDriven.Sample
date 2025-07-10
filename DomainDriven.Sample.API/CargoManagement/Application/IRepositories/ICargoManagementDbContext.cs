using DomainDriven.Sample.API.CargoManagement.Domain.Aggregates;
using DomainDriven.Sample.API.Common;
using Microsoft.EntityFrameworkCore;

namespace DomainDriven.Sample.API.CargoManagement.Application.IRepositories
{
    public interface ICargoManagementDbContext : IBaseDbContext
    {
        public DbSet<CargoReadModel> CargoReadModel { get; set; }
        public DbSet<Company> Company { get; set; }
    }
}
