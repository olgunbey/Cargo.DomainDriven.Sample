using DomainDriven.Sample.API.Common;

namespace DomainDriven.Sample.API.Feature.Order.Domain.Events
{
    public record CreateOrderEvent(
        Guid OrderId,
        IEnumerable<(Guid ProductId, string ProductName, int Count)> ProductItems,
        Guid DistrictId,
        string DistrictName,
        Guid CityId,
        string CityName,
        string Detail
        ) : ICustomizeNotification
    {
        public bool ShouldLogEvent { get; set; }
    }
}
