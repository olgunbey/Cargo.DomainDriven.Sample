using DomainDriven.Sample.API.Common;

namespace DomainDriven.Sample.API.Feature.Location.Domain.Aggregates
{
    public class CustomerOrderTargetLocation : AggregateRoot
    {
        public Guid CustomerId { get; private set; }
        public Guid CityId { get; private set; }
        public Guid DistrictId { get; private set; }
        public string Detail { get; private set; }

        public CustomerOrderTargetLocation(Guid customerId, Guid cityId, Guid districtId, string detail)
        {
            this.CustomerId = customerId;
            this.CityId = cityId;
            this.DistrictId = districtId;
            this.Detail = detail;
        }
    }
}
