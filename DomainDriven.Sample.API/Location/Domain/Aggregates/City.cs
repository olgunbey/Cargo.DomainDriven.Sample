using DomainDriven.Sample.API.Common;
using DomainDriven.Sample.API.Location.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace DomainDriven.Sample.API.Location.Domain.Aggregates
{
    public class City : AggregateRoot
    {
        public City()
        {

        }
        public string Name { get; private set; }
        private readonly List<District> _districts;
        public IReadOnlyCollection<District> Districts => _districts;

        public void SetName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("City name cannot be null or empty.", nameof(name));
            }
            this.Name = name;
        }
        public void AddDistrict(string name)
        {
            if (_districts.Any(d => d.Name == name))
            {
                throw new InvalidOperationException($"District with ID {name} already exists in the city.");
            }
            _districts.Add(new District().GenerateDistrict(name));
        }
        public City GenerateCity(string name)
        {
            this.Name = name;
            return this;
        }
    }
}
