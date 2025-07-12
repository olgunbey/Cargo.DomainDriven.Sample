using DomainDriven.Sample.API.CargoManagement.Domain.ValueObjects;

namespace DomainDriven.Sample.API.Order.Domain.ValueObjects
{
    public class TargetLocation : ValueObject
    {
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
