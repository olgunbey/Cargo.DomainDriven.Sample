using DomainDriven.Sample.API.Feature.Location.Domain.Aggregates;

namespace DomainDriven.Sample.API.Feature.Location.Domain.Interfaces
{
    public interface ICity
    {
        public City AddCity(string cityName);
        public void AddDistrict(string districtName);
        public void UpdateCity(int id, string cityName);
    }
}
