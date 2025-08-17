using DomainDriven.Sample.API.Common;
using DomainDriven.Sample.API.Feature.Order.Domain.Entities;
using DomainDriven.Sample.API.Feature.Order.Domain.Enums;
using DomainDriven.Sample.API.Feature.Order.Domain.Events;

namespace DomainDriven.Sample.API.Feature.Order.Domain.Aggregates
{
    public class OrderInformation : AggregateRoot
    {
        public OrderInformation()
        {

        }
        public OrderInformation(Guid cityId, Guid districtId, string detail, int customerId, List<(Guid ProductId, string ProductName, int Count)> productItems, bool paymentStatus, string cityName, string districtName)
        {
            var enumerableProductItems = productItems.Select(x => new ProductItem(x.ProductId, x.Count));
            CustomerId = customerId;
            PaymentStatus = paymentStatus;
            RaiseDomainEvent(new CreateOrderEvent(this.Id, productItems,districtId,districtName,cityId,cityName,detail) { ShouldLogEvent = true });
        }
        public OrderStatus OrderStatus { get; private set; }
        public int CustomerId { get; private set; }
        public bool PaymentStatus { get; private set; }
        public void UpdateStatus(OrderStatus status)
        {
            this.OrderStatus = status;
        }
    }
}
