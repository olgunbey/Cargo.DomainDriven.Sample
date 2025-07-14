using DomainDriven.Sample.API.Common;
using Microsoft.EntityFrameworkCore;

namespace DomainDriven.Sample.API.Employee.Application.IRepositories
{
    public interface IEmployeeDbContext : IBaseDbContext
    {
        public DbSet<Domain.Aggregates.Employee> Employe { get; set; }
    }
}
