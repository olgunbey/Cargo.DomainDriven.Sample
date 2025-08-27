using DomainDriven.Sample.API.Feature.Order.Domain.ReadModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DomainDriven.Sample.API.Feature.Order.Infrastructure.Persistence.DatabaseConfig
{
    public class OrderProductReadModelConfiguration : IEntityTypeConfiguration<OrderProductReadModel>
    {
        public void Configure(EntityTypeBuilder<OrderProductReadModel> builder)
        {
            builder.HasKey(y => y.Id);
        }
    }
}
