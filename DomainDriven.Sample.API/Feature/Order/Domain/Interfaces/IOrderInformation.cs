using DomainDriven.Sample.API.Feature.Order.Domain.Aggregates;

namespace DomainDriven.Sample.API.Feature.Order.Domain.Interfaces
{
    public interface IOrderInformation
    {
        public OrderInformation CreateOrder(int districtId, int cityId, string detail, int customerId, List<(int ProductId, int Count)> values, bool PaymentStatus);
    }
}
