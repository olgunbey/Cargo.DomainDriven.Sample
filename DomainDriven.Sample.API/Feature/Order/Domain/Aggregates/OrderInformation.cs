using DomainDriven.Sample.API.Common;
using DomainDriven.Sample.API.Feature.Order.Domain.Enums;
using DomainDriven.Sample.API.Feature.Order.Domain.ValueObjects;

namespace DomainDriven.Sample.API.Feature.Order.Domain.Aggregates
{
    public class OrderInformation : AggregateRoot
    {
        public OrderStatus OrderStatus { get; private set; }
        public TargetLocation TargetLocation { get; private set; }
        public int CustomerId { get; private set; }
        public bool PaymentStatus { get; private set; }
        public List<int> ProductItemsId { get; private set; }
    }
}
