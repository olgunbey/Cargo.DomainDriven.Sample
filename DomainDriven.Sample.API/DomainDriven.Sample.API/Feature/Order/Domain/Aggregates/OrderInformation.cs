using DomainDriven.Sample.API.Common;
using DomainDriven.Sample.API.Feature.Order.Domain.Enums;
using DomainDriven.Sample.API.Feature.Order.Domain.Events;

namespace DomainDriven.Sample.API.Feature.Order.Domain.Aggregates
{
    public class OrderInformation : AggregateRoot
    {
        public OrderInformation()
        {

        }
        public OrderInformation(Guid customerId, Guid orderLocationId)
        {
            this.CustomerId = customerId;
            this.PaymentStatus = false;
            this.OrderLocationId = orderLocationId;
        }
        public OrderStatus OrderStatus { get; private set; }
        public Guid CustomerId { get; private set; }
        public bool PaymentStatus { get; private set; }
        public Guid OrderLocationId { get; private set; }
        public void CreateOrder(Guid districtId, string districtName, Guid cityId, string cityName, string detail, List<(Guid id, int quantity, string name, int price)> productItems)
        {
            OrderStatus = OrderStatus.Accepted;
            RaiseDomainEvent(new CreateOrderEvent(this.Id, productItems, cityId, cityName, districtId, this.OrderLocationId, districtName, detail, this.CustomerId, this.OrderStatus) { ShouldLogEvent = true });
        }
        public void UpdateStatus(OrderStatus status)
        {
            if (status == OrderStatus.AtDistributionCenter) //artık bunlar cargo BC'sine gidecek
            {
                RaiseDomainEvent(new UpdateStatusOrderEvent(this.Id, status));
            }
            this.OrderStatus = status;
        }
    }
}
