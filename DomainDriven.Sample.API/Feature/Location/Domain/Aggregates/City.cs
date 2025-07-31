using DomainDriven.Sample.API.Common;
using DomainDriven.Sample.API.Feature.Location.Domain.Entities;
using DomainDriven.Sample.API.Feature.Location.Domain.Events.City;
using DomainDriven.Sample.API.Feature.Location.Domain.Events.District;
using DomainDriven.Sample.API.Feature.Location.Domain.Interfaces;

namespace DomainDriven.Sample.API.Feature.Location.Domain.Aggregates
{
    public class City : AggregateRoot, ICity
    {
        public string Name { get; private set; }
        private readonly List<District> _districts = new();
        public IReadOnlyCollection<District> Districts => _districts;


        public City AddCity(string cityName)
        {
            this.Name = cityName;
            RaiseDomainEvent(new AddCityEvent(this.Name, this.Id));
            return this;
        }

        public void AddDistrict(string districtName)
        {
            _districts.Add(new District(Name));
        }
        public void UpdateCity(Guid id, string cityName)
        {
            this.Name = cityName;
            RaiseDomainEvent(new UpdateCityEvent(id, cityName));
        }
        public void UpdateDistrict(Guid districtId, string districtName)
        {
            var updateDistrict = _districts.Single(y => y.Id == districtId);

            updateDistrict.UpdateName(districtName);

            RaiseDomainEvent(new UpdateDistrictEvent(districtId, districtName));
        }
    }
}
