using DomainDriven.Sample.API.Common;

namespace DomainDriven.Sample.API.Feature.Order.Domain.ValueObjects
{
    public class TargetLocation : ValueObject
    {
        public TargetLocation(Guid cityId, Guid districtId, string detail)
        {
            CityId = cityId;
            DistrictId = districtId;
            Detail = detail;
        }
        public Guid CityId { get; private set; }
        public Guid DistrictId { get; private set; }
        public string Detail { get; private set; }
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return CityId;
            yield return DistrictId;
            yield return Detail;
        }
    }
}
