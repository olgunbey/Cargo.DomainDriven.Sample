using DomainDriven.Sample.API.Common;
using DomainDriven.Sample.API.Feature.Order.Domain.Enums;
using DomainDriven.Sample.API.Feature.Order.Domain.Events;
using DomainDriven.Sample.API.Feature.Order.Domain.Interfaces;
using DomainDriven.Sample.API.Feature.Order.Domain.ValueObjects;

namespace DomainDriven.Sample.API.Feature.Order.Domain.Aggregates
{
    public class OrderInformation : AggregateRoot, IOrderInformation
    {
        public OrderStatus OrderStatus { get; private set; }
        public TargetLocation TargetLocation { get; private set; }
        public int CustomerId { get; private set; }
        public bool PaymentStatus { get; private set; }
        private readonly List<int> _productItemIds;
        public IReadOnlyCollection<int> ProductItemIds => _productItemIds;

        public OrderInformation CreateOrder(int districtId, int cityId, string detail, int customerId, List<int> productItemIds, bool paymentStatus)
        {
            _productItemIds.AddRange(productItemIds);
            TargetLocation = new TargetLocation(cityId, districtId, detail);
            CustomerId = customerId;
            PaymentStatus = paymentStatus;
            RaiseDomainEvent(new CreateOrderEvent(productItemIds, customerId, TargetLocation, paymentStatus) { ShouldLogEvent = true });
            return this;
        }
    }
}
