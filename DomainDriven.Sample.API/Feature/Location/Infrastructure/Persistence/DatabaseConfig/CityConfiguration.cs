using DomainDriven.Sample.API.Feature.Location.Domain.Aggregates;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DomainDriven.Sample.API.Feature.Location.Infrastructure.Persistence.DatabaseConfig
{
    public class CityConfiguration : IEntityTypeConfiguration<City>
    {
        public void Configure(EntityTypeBuilder<City> builder)
        {
            //builder.Property(y => y.Id).UseHiLo();
        }
    }
}
