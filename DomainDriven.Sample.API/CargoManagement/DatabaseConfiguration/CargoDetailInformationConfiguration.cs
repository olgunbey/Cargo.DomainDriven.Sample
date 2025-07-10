using DomainDriven.Sample.API.CargoManagement.Domain.Aggregates;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DomainDriven.Sample.API.CargoManagement.DatabaseConfiguration
{
    public class CargoDetailInformationConfiguration : IEntityTypeConfiguration<CargoDetailInformation>
    {
        public void Configure(EntityTypeBuilder<CargoDetailInformation> builder)
        {
            builder.HasIndex(y => y.CargoCode)
                .IsUnique();
        }
    }
}
