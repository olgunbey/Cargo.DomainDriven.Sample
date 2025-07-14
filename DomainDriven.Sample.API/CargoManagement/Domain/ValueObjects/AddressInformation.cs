
using DomainDriven.Sample.API.Common;

namespace DomainDriven.Sample.API.CargoManagement.Domain.ValueObjects
{
    public class AddressInformation : ValueObject
    {
        public AddressInformation(int cityId, string detail, int districtId)
        {
            CityId = cityId;
            Detail = detail;
            DistrictId = districtId;
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
