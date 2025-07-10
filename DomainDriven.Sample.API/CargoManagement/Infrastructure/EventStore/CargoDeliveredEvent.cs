namespace DomainDriven.Sample.API.CargoManagement.Infrastructure.EventStore
{
    public record CargoDeliveredEvent : CargoBaseEvent
    {
        public CargoDeliveredEvent(string CargoCode, int? EmpoyeeId, int CustomerId) : base(CargoCode, EmpoyeeId, CustomerId)
        {
        }
    }
}
