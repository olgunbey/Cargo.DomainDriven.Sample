using DomainDriven.Sample.API.Common;

namespace DomainDriven.Sample.API.Feature.Order.Domain.Events
{
    public record CreateOrderEvent(
        Guid OrderId,
        List<(Guid id, int quantity, string name,int price)> ProductItems,
        Guid CityId,
        string CityName,
        Guid DistrictId,
        Guid TargetLocationId,
        string DistrictName,
        string Detail,
        Guid CustomerId
        ) : ICustomizeNotification
    {
        public bool ShouldLogEvent { get; set; }
    }
}
