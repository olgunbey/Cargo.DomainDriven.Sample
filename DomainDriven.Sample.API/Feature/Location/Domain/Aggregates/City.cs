using DomainDriven.Sample.API.Common;

namespace DomainDriven.Sample.API.Feature.Location.Domain.Aggregates
{
    public class City : AggregateRoot
    {
        public string Name { get; private set; }
        private readonly List<int> _districtIds;
        public IReadOnlyCollection<int> DistrictIds => _districtIds;
    }
}
