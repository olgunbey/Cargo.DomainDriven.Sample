
using DomainDriven.Sample.API.Common;

namespace DomainDriven.Sample.API.CargoManagement.Domain.ValueObjects
{
    public class TargetLocation : ValueObject
    {
        public TargetLocation(int cityId, int districtId, string detail)
        {
            CityId = cityId;
            DistrictId = districtId;
            Detail = detail;
        }
        public int CityId { get; private set; }
        public int DistrictId { get; private set; }
        public string Detail { get; private set; }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return CityId;
            yield return DistrictId;
            yield return Detail;
        }
    }
}
