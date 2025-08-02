using DomainDriven.Sample.API.Common;
using DomainDriven.Sample.API.Feature.Order.Domain.ReadModel;
using Microsoft.EntityFrameworkCore;

namespace DomainDriven.Sample.API.Feature.Order.Application.Interfaces
{
    public interface IOrderDbContext : IBaseDbContext
    {
        public DbSet<Domain.Aggregates.OrderInformation> OrderInformation { get; set; }

        public DbSet<OrderProductReadModel> OrderProductRealModel { get; set; }
    }
}
