using DomainDriven.Sample.API.Feature.Order.Domain.Aggregates;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DomainDriven.Sample.API.Feature.Order.Infrastructure.Persistence.DatabaseConfig
{
    public class OrderInformationConfiguration : IEntityTypeConfiguration<OrderInformation>
    {
        public void Configure(EntityTypeBuilder<OrderInformation> builder)
        {
            builder.OwnsOne(y => y.TargetLocation);
        }
    }
}
