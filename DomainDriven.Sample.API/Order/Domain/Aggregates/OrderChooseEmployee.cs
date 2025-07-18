using DomainDriven.Sample.API.Common;
using DomainDriven.Sample.API.Order.Domain.Events;
using DomainDriven.Sample.API.Order.Domain.Repository;

namespace DomainDriven.Sample.API.Order.Domain.Aggregates
{
    public class OrderChooseEmployee : AggregateRoot, IOrderChooseEmployee
    {
        public int OrderId { get; private set; }
        public int EmployeeId { get; private set; }

        public OrderChooseEmployee GenerateOrderChooseEmployee(int orderId, int employeeId)
        {
            this.OrderId = orderId;
            this.EmployeeId = employeeId;
            RaiseDomainEvent(new GenerateOrderChooseEmployeeEvent(orderId, employeeId));
            return this;

        }
    }
}
