using DomainDriven.Sample.API.Feature.Order.Domain.Enums;
using DomainDriven.Sample.API.IntegrationEvents;

namespace DomainDriven.Sample.API.Feature.Order.Application.Dtos
{
    public static class OrderStatusMapper
    {
        public static OrderStatus MapToDomain(CargoStatusDto cargoStatus)
        {
            return cargoStatus switch
            {
                CargoStatusDto.Returned => OrderStatus.Returned,
                CargoStatusDto.InTransit => OrderStatus.InTransit,
                CargoStatusDto.AtDistributionCenter => OrderStatus.AtDistributionCenter,
                CargoStatusDto.Cancelled => OrderStatus.Cancelled,
                CargoStatusDto.Delivered => OrderStatus.Delivered,
                CargoStatusDto.OutForDelivery => OrderStatus.OutForDelivery,
                CargoStatusDto.Rejected => OrderStatus.Rejected,
                CargoStatusDto.PickedUp => OrderStatus.PickedUp
            };
        }
    }
}
