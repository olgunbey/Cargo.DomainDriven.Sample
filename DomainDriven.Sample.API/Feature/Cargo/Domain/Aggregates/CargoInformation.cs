using DomainDriven.Sample.API.Common;
using DomainDriven.Sample.API.Feature.Cargo.Domain.Enums;
using DomainDriven.Sample.API.Feature.Cargo.Domain.Events;
using DomainDriven.Sample.API.Feature.Cargo.Domain.ValueObjects;

namespace DomainDriven.Sample.API.Feature.Cargo.Domain.Aggregates
{
    public class CargoInformation : AggregateRoot
    {
        public CargoInformation(int companyId, DateTime estimatedDateTime, Guid orderId)
        {
            CompanyId = companyId;
            OrderId = orderId;
            EstimateDateTime = estimatedDateTime;
            CargoStatus = CargoStatus.PickedUp;
            CreatedDate = DateTime.UtcNow;
            CargoCode = "Test123";
            RaiseDomainEvent(new GenerateCargoEvent(companyId, orderId, estimatedDateTime, CreatedDate, CargoCode) { ShouldLogEvent = true });
        }
        public int CompanyId { get; private set; }
        public Guid OrderId { get; set; }
        public CargoStatus CargoStatus { get; private set; }
        public string CargoCode { get; private set; }
        public DateTime EstimateDateTime { get; private set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdateDateTime { get; set; }
        public TargetLocation TargetLocation { get; private set; }

        public void UpdateCargoStatus(CargoStatus cargoStatus)
        {
            CargoStatus = cargoStatus;
            UpdateDateTime = DateTime.UtcNow;
            RaiseDomainEvent(new UpdateCargoStatusEvent(cargoStatus, UpdateDateTime, CargoCode, OrderId) { ShouldLogEvent = true });
        }
        public void AddProduct(IEnumerable<(Guid Id, string Name)> products)
        {
            RaiseDomainEvent(new AddProductEvent(products, this.Id));
        }
    }
}
