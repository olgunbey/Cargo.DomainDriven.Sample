using DomainDriven.Sample.API.Common;
using DomainDriven.Sample.API.Feature.Order.Domain.Entities;
using DomainDriven.Sample.API.Feature.Order.Domain.Enums;
using DomainDriven.Sample.API.Feature.Order.Domain.Events;
using DomainDriven.Sample.API.Feature.Order.Domain.ValueObjects;

namespace DomainDriven.Sample.API.Feature.Order.Domain.Aggregates
{
    public class OrderInformation : AggregateRoot
    {
        public OrderInformation(Guid cityId, Guid districtId, string detail, int customerId, List<(Guid ProductId, string ProductName,int Count )> productItems, bool paymentStatus)
        {
            var eumerableProductItems = productItems.Select(x => new ProductItem(x.ProductId, x.Count));
            _productItem.AddRange(eumerableProductItems);
            TargetLocation = new TargetLocation(cityId, districtId, detail);
            CustomerId = customerId;
            PaymentStatus = paymentStatus;
            RaiseDomainEvent(new CreateOrderEvent(this.Id, productItems) { ShouldLogEvent = true });
        }
        public OrderStatus OrderStatus { get; private set; }
        public TargetLocation TargetLocation { get; private set; }
        public int CustomerId { get; private set; }
        public bool PaymentStatus { get; private set; }
        private readonly List<ProductItem> _productItem = new();
        public IReadOnlyCollection<ProductItem> ProductItem => _productItem;

        public void UpdateStatus(OrderStatus status)
        {
            this.OrderStatus = status;
        }
    }
}
