using DomainDriven.Sample.API.Common;
using DomainDriven.Sample.API.Feature.Cargo.Domain.Enums;
using DomainDriven.Sample.API.Feature.Cargo.Domain.Events;

namespace DomainDriven.Sample.API.Feature.Cargo.Domain.Aggregates
{
    public class CargoInformation : AggregateRoot
    {
        public CargoInformation()
        {

        }
        public CargoInformation(Guid orderId, CargoStatus cargoStatus, Guid cityId, string cityName, Guid districtId, string districtName, string detail, DateTime estimatedDateTime = default)
        {
            OrderId = orderId;
            EstimateDateTime = estimatedDateTime;
            CargoStatus = cargoStatus;
            CreatedDate = DateTime.UtcNow;
            CargoCode = "Test123";
        }
        public Guid OrderId { get; private set; }
        public CargoStatus CargoStatus { get; private set; }
        public string CargoCode { get; private set; }
        public DateTime? EstimateDateTime { get; private set; }
        public DateTime CreatedDate { get; private set; }
        public DateTime UpdateDateTime { get; private set; }

        public void UpdateCargoStatus(CargoStatus cargoStatus)
        {
            CargoStatus = cargoStatus;
            UpdateDateTime = DateTime.UtcNow;
            RaiseDomainEvent(new UpdateCargoStatusEvent(cargoStatus, UpdateDateTime, CargoCode, OrderId) { ShouldLogEvent = true });
        }
    }
}
