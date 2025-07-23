using DomainDriven.Sample.API.Common;
using DomainDriven.Sample.API.Feature.Cargo.Domain.Enums;
using DomainDriven.Sample.API.Feature.Cargo.Domain.Events;
using DomainDriven.Sample.API.Feature.Cargo.Domain.Interfaces;

namespace DomainDriven.Sample.API.Feature.Cargo.Domain.Aggregates
{
    public class CargoInformation : AggregateRoot, ICargoInformation
    {
        public int CompanyId { get; private set; }
        public int OrderId { get; private set; }
        public CargoStatus CargoStatus { get; private set; }
        public string CargoCode { get; private set; }
        public DateTime EstimateDateTime { get; private set; }

        public CargoInformation GenerateCargo(int companyId, DateTime estimatedDateTime, int orderId)
        {
            CompanyId = companyId;
            OrderId = orderId;
            EstimateDateTime = estimatedDateTime;
            CargoStatus = CargoStatus.PickedUp;
            RaiseDomainEvent(new GenerateCargoEvent(companyId, orderId, estimatedDateTime) { ShouldLogEvent = true });
            return this;
        }
    }
}
