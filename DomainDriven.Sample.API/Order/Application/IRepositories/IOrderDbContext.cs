using DomainDriven.Sample.API.Common;
using DomainDriven.Sample.API.Employee.Application.Queries;
using DomainDriven.Sample.API.Order.Application.ReadModels;
using DomainDriven.Sample.API.Order.Domain.Aggregates;
using Microsoft.EntityFrameworkCore;

namespace DomainDriven.Sample.API.Order.Application.IRepositories
{
    public interface IOrderDbContext : IBaseDbContext
    {
        public DbSet<Domain.Aggregates.Order> Order { get; set; }
        public DbSet<OrderCustomerReadModel> CustomerReadModel { get; set; }
        public DbSet<OrderChooseEmployee> OrderChooseEmployee { get; set; }

    }
}
