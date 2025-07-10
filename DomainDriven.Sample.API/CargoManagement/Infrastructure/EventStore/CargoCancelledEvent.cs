namespace DomainDriven.Sample.API.CargoManagement.Infrastructure.EventStore
{
    public record CargoCancelledEvent : CargoBaseEvent
    {
        public CargoCancelledEvent(string CargoCode, int? EmpoyeeId, int CustomerId) : base(CargoCode, EmpoyeeId, CustomerId)
        {
        }
    }
}
