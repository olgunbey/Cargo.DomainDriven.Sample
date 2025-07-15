using DomainDriven.Sample.API.Employee.Domain.Aggregates;

namespace DomainDriven.Sample.API.Employee.Domain.Repositories
{
    public interface ISelectedEmployee
    {
        public SelectedEmployee CreateSelectedEmployee(int orderId, int employeeId);
    }
}
