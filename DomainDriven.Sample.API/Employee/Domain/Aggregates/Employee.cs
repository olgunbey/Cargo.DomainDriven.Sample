using DomainDriven.Sample.API.Common;
using DomainDriven.Sample.API.Employee.Domain.Events;

namespace DomainDriven.Sample.API.Employee.Domain.Aggregates
{
    public class Employee : AggregateRoot
    {
        public Employee()
        {
            _cargoIds = new List<int>();
        }
        private List<int> _cargoIds;
        public IReadOnlyCollection<int> CargoIds => _cargoIds;

        public void AssignCargo(int cargoId)
        {
            if (_cargoIds.Contains(cargoId))
            {
                throw new InvalidOperationException("Cargo is already assigned to this employee.");
            }
            _cargoIds.Add(cargoId);
            RaiseDomainEvent(new CargoAssignedNotification(this.Id, cargoId));
        }
    }
}
