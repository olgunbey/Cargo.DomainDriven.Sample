using DomainDriven.Sample.API.Common;
using DomainDriven.Sample.API.Feature.Location.Domain.Entities;
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
            return this;
        }

        public void AddDistrict(string districtName)
        {
            _districts.Add(new District(Name));
        }
    }
}
