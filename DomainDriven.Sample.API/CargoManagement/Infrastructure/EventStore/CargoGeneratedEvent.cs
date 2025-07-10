namespace DomainDriven.Sample.API.CargoManagement.Infrastructure.EventStore
{
    public record CargoGeneratedEvent : CargoBaseEvent
    {
        public CargoGeneratedEvent(string CargoCode, int? EmpoyeeId, int CustomerId) : base(CargoCode, EmpoyeeId, CustomerId)
        {
        }
    }
}
