using DomainDriven.Sample.API.Order.Domain.Aggregates;

namespace DomainDriven.Sample.API.Order.Domain.Repository
{
    public interface IOrderChooseEmployee
    {
        public OrderChooseEmployee GenerateOrderChooseEmployee(int orderId, int employeeId);
    }
}
