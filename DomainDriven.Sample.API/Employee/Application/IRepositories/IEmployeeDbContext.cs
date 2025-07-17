using DomainDriven.Sample.API.Common;
using DomainDriven.Sample.API.Employee.Application.Queries;
using DomainDriven.Sample.API.Employee.Domain.Aggregates;
using Microsoft.EntityFrameworkCore;

namespace DomainDriven.Sample.API.Employee.Application.IRepositories
{
    public interface IEmployeeDbContext : IBaseDbContext
    {
        public DbSet<Domain.Aggregates.Employee> Employe { get; set; }
        public DbSet<ApprovedCargoEmployee> SelectedEmployee { get; set; }
        public DbSet<CustomerAndOrderEmployeeReadModel> CustomerAndOrderEmployeeReadModel { get; set; }
    }
}
