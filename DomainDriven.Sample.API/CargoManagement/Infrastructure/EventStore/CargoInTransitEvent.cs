using DomainDriven.Sample.API.CargoManagement.Infrastructure.EventStore;

namespace DomainDriven.Sample.API.CargoManagement.Domain.Events
{
    public record CargoInTransitEvent : CargoBaseEvent
    {
        public CargoInTransitEvent(string CargoCode, int? EmpoyeeId, int CustomerId) : base(CargoCode, EmpoyeeId, CustomerId)
        {
        }
    }
}
