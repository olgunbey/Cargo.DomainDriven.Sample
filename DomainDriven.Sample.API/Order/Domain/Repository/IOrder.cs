namespace DomainDriven.Sample.API.Order.Domain.Repository
{
    public interface IOrder
    {
        void AddOrderItem(string name, decimal weight, int count);
        Aggregates.Order GenerateOrder(int customerId, int cityId, int districtId, string detail);
    }
}
