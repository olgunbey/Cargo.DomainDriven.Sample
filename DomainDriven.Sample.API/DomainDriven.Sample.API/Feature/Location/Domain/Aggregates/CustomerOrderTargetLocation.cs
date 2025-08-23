using DomainDriven.Sample.API.Common;
using DomainDriven.Sample.API.Feature.Location.Domain.Events;

namespace DomainDriven.Sample.API.Feature.Location.Domain.Aggregates
{
    public class CustomerOrderTargetLocation : AggregateRoot
    {
        public Guid CustomerId { get; private set; }
        public string LocationHeader { get; private set; }
        public Guid CityId { get; private set; }
        public Guid DistrictId { get; private set; }
        public string Detail { get; private set; }

        public CustomerOrderTargetLocation(string locationHeader, Guid customerId, Guid cityId, Guid districtId, string detail)
        {
            this.CustomerId = customerId;
            this.CityId = cityId;
            this.DistrictId = districtId;
            this.Detail = detail;
            this.LocationHeader = locationHeader;
        }
        public void CreateLocation()
        {
            RaiseDomainEvent(new CreateCustomerOrderTargetLocationEvent(this.Id, this.CityId, this.DistrictId, this.Detail, this.CustomerId, this.LocationHeader));
        }
        public void RemoveTargetLocation()
        {
            RaiseDomainEvent(new RemoveCustomerOrderTargetLocationEvent(this.Id));
        }
    }
}
