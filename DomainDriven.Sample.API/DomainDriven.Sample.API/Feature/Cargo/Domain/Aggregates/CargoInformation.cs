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
        public CargoInformation(int companyId, DateTime estimatedDateTime, Guid orderId, Guid cityId, string cityName, Guid districtId, string districtName, Dictionary<Guid, string> products, string detail)
        {
            _productIds = new();
            CompanyId = companyId;
            OrderId = orderId;
            EstimateDateTime = estimatedDateTime;
            CargoStatus = CargoStatus.PickedUp;
            CreatedDate = DateTime.UtcNow;
            CargoCode = "Test123";
            _productIds.AddRange(products.Select(y => y.Key));
            RaiseDomainEvent(new GenerateCargoEvent(companyId, this.Id, orderId, estimatedDateTime, CreatedDate, CargoCode, cityId, cityName, districtId, districtName, products, detail) { ShouldLogEvent = true });
        }
        public int CompanyId { get; private set; }
        public Guid OrderId { get; private set; }

        private readonly List<Guid> _productIds;
        public IReadOnlyCollection<Guid> ProductIds => _productIds.AsReadOnly();
        public CargoStatus CargoStatus { get; private set; }
        public string CargoCode { get; private set; }
        public DateTime EstimateDateTime { get; private set; }
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
