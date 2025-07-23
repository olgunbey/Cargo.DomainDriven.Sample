using DomainDriven.Sample.API.Common;
using Microsoft.EntityFrameworkCore;

namespace DomainDriven.Sample.API.Feature.Order.Application.Interfaces
{
    public interface IOrderDbContext:IBaseDbContext
    {
        public DbSet<Domain.Aggregates.OrderInformation> OrderInformation { get; set; }
    }
}
