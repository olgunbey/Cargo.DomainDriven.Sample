using DomainDriven.Sample.API.Employee.Domain.Aggregates;

namespace DomainDriven.Sample.API.Employee.Domain.Repositories
{
    public interface IApprovedCargoEmployee
    {
        public ApprovedCargoEmployee CreateApprovedEmployee(int orderId, int employeeId);
    }
}
