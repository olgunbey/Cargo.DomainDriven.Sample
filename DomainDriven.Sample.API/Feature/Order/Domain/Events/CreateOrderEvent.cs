using DomainDriven.Sample.API.Common;

namespace DomainDriven.Sample.API.Feature.Order.Domain.Events
{
    public record CreateOrderEvent(
        Guid OrderId,
        IEnumerable<(Guid ProductId, string ProductName, int Count)> ProductItems
        ) : ICustomizeNotification
    {
        public bool ShouldLogEvent { get; set; }
    }
}
