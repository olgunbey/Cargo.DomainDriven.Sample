using DomainDriven.Sample.API.Common;
using DomainDriven.Sample.API.Employee.Domain.Repositories;

namespace DomainDriven.Sample.API.Employee.Domain.Aggregates
{
    public class SelectedEmployee : AggregateRoot, ISelectedEmployee
    {
        public int OrderId { get; private set; }
        public int EmployeeId { get; private set; }
        public bool Approval { get; private set; }

        public SelectedEmployee CreateSelectedEmployee(int orderId, int employeeId)
        {
            this.OrderId = orderId;
            this.EmployeeId = employeeId;
            return this;
        }
        public void SetApproval()
        {
            this.Approval = true;
        }
    }
}