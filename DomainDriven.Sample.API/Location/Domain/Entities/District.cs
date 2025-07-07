using DomainDriven.Sample.API.Common;
using DomainDriven.Sample.API.Location.Domain.Repositories;

namespace DomainDriven.Sample.API.Location.Domain.Entities
{
    public class District : IEntity,IDistrict
    {
        public District()
        {
            _neighbourhoods = new List<Neighbourhood>();
        }
        public int Id { get; private set; }
        public string Name { get; private set; }
        private List<Neighbourhood> _neighbourhoods;
        public IReadOnlyCollection<Neighbourhood> Neighbourhoods => _neighbourhoods;
        public District GenerateDistrict(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("District name cannot be null or empty.", nameof(name));

            this.Name = name;
            return this;
        }
        public void AddNeighbourhood(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Neighbourhood name cannot be null or empty.", nameof(name));

            if (_neighbourhoods.Any(n => n.Name == name))
                throw new InvalidOperationException($"Neighbourhood with ID {name} already exists in the district.");

            _neighbourhoods.Add(new Neighbourhood().GenerateNeighbourhood(name));
        }
    }
}
