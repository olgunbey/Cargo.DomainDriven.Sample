using DomainDriven.Sample.API.Feature.Cargo.Domain.Enums;
using DomainDriven.Sample.API.IntegrationEvents;

namespace DomainDriven.Sample.API.Feature.Cargo.Application.Dtos
{
    public static class OrderStatusMapper
    {
        public static CargoStatus MapToDto(EventOrderStatus cargoStatus) => cargoStatus switch { EventOrderStatus.AtDistributionCenter => CargoStatus.AtDistributionCenter };

    };

}
