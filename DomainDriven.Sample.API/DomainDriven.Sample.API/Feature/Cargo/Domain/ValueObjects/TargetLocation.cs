using DomainDriven.Sample.API.Common;

namespace DomainDriven.Sample.API.Feature.Cargo.Domain.ValueObjects
{
    public class TargetLocation : ValueObject
    {
        public TargetLocation(int cityId, string cityName, int districtId, string districtName, string detail)
        {
            this.CityId = cityId;
            this.CityName = cityName;
            this.DistrictId = districtId;
            this.DistrictName = districtName;
            this.Detail = detail;
        }
        public int CityId { get; private set; }
        public string CityName { get; private set; }
        public int DistrictId { get; private set; }
        public string DistrictName { get; private set; }
        public string Detail { get; private set; }


        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return CityId;
            yield return CityName;
            yield return DistrictId;
            yield return DistrictName;
            yield return Detail;
        }
    }
}
