using DomainDriven.Sample.API.Common;
using DomainDriven.Sample.API.Employee.Domain.Events;
using DomainDriven.Sample.API.Employee.Domain.Repositories;

namespace DomainDriven.Sample.API.Employee.Domain.Aggregates
{
    public class ApprovedCargoEmployee : AggregateRoot, IApprovedCargoEmployee
    {
        public int OrderId { get; private set; }
        public int EmployeeId { get; private set; }
        public bool Approval { get; private set; }

        public ApprovedCargoEmployee CreateApprovedEmployee(int orderId, int employeeId)
        {
            this.OrderId = orderId;
            this.EmployeeId = employeeId;
            return this;
        }
        public void SetApproval(bool approval)
        {
            this.Approval = approval;
            RaiseDomainEvent(new EmployeeCargoApprovedEvent(this.OrderId, this.Approval));
        }
    }
}