using DomainDriven.Sample.API.Common;
using DomainDriven.Sample.API.Feature.Order.Domain.Entities;
using DomainDriven.Sample.API.Feature.Order.Domain.ValueObjects;

namespace DomainDriven.Sample.API.Feature.Order.Domain.Events
{
    public record CreateOrderEvent(List<ProductItem> ProductItemIds, int CustomerId, TargetLocation targetLocation ,bool PaymentStatus) : ICustomizeNotification
    {
        public bool ShouldLogEvent { get; set; }
    }
}
