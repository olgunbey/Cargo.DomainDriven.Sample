using DomainDriven.Sample.API.IntegrationEvents;

namespace DomainDriven.Sample.API.Feature.Cargo.Application.Dtos
{
    public static class OrderStatusMapper
    {
        public static CargoStatusDto MapToDto(Domain.Enums.CargoStatus cargoStatus)
        {
            return cargoStatus switch
            {
                Domain.Enums.CargoStatus.Returned => CargoStatusDto.Returned,
                Domain.Enums.CargoStatus.Cancelled => CargoStatusDto.Cancelled,
                Domain.Enums.CargoStatus.OutForDelivery => CargoStatusDto.OutForDelivery,
                Domain.Enums.CargoStatus.Delivered => CargoStatusDto.Delivered,
                Domain.Enums.CargoStatus.InTransit => CargoStatusDto.InTransit,
                Domain.Enums.CargoStatus.AtDistributionCenter => CargoStatusDto.AtDistributionCenter,
                Domain.Enums.CargoStatus.PickedUp => CargoStatusDto.PickedUp,
                Domain.Enums.CargoStatus.Rejected => CargoStatusDto.Rejected,
            };

        }
    }
}
