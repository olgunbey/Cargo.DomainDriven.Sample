using DomainDriven.Sample.API.Common;
using DomainDriven.Sample.API.Feature.Order.Domain.Enums;

namespace DomainDriven.Sample.API.Feature.Order.Domain.Events
{
    public record UpdateStatusOrderEvent(
        Guid OrderId,
        OrderStatus OrderStatus
        ) : ICustomizeNotification
    {
        public bool ShouldLogEvent { get; set; }
    }
}
