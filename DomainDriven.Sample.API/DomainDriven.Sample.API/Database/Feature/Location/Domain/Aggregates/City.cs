using DomainDriven.Sample.API.Common;
using DomainDriven.Sample.API.Feature.Location.Domain.Entities;


namespace DomainDriven.Sample.API.Feature.Location.Domain.Aggregates
{
    public class City : AggregateRoot
    {
        public City()
        {
            
        }
        public City(string cityName)
        {
            this.Name = cityName;
        }
        public string Name { get; private set; }
        private readonly List<District> _districts = new();
        public IReadOnlyCollection<District> Districts => _districts;


        public void AddDistrict(string districtName)
        {
            _districts.Add(new District(Name));
        }
        public void UpdateCity(Guid id, string cityName)
        {
            this.Name = cityName;
        }
        public void UpdateDistrict(Guid districtId, string districtName)
        {
            var updateDistrict = _districts.Single(y => y.Id == districtId);
            updateDistrict.UpdateName(districtName);
        }
    }
}
