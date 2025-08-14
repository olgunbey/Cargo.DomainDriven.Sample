using DomainDriven.Sample.API.Common;
using Microsoft.EntityFrameworkCore;

namespace DomainDriven.Sample.API.Feature.Product.Application.Interfaces
{
    public interface IProductDbContext : IBaseDbContext
    {
        public DbSet<Domain.Aggregates.Product> Product { get; set; }
        public DbSet<Domain.Aggregates.Category> Category { get; set; }
    }
}
