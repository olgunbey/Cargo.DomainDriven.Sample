using DomainDriven.Sample.API.Common;
using Microsoft.EntityFrameworkCore;

namespace DomainDriven.Sample.API.Order.Application.IRepositories
{
    public interface IOrderDbContext : IBaseDbContext
    {
        public DbSet<Domain.Aggregates.Order> Order { get; set; }

    }
}
