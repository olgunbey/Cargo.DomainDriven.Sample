using DomainDriven.Sample.API.Common;
using DomainDriven.Sample.API.Location.Domain.Repositories;

namespace DomainDriven.Sample.API.Location.Domain.Entities
{
    public class Neighbourhood : IEntity, INeighbourhood
    {
        public Neighbourhood()
        {

        }
        public int Id { get; private set; }
        public string Name { get; private set; }
        public Neighbourhood GenerateNeighbourhood(string Name)
        {
            this.Name = Name;
            return this;
        }
    }
}
