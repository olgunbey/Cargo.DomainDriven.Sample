using DomainDriven.Sample.API.Location.Domain.Entities;

namespace DomainDriven.Sample.API.Location.Domain.Repositories
{
    public interface INeighbourhood
    {
        public Neighbourhood GenerateNeighbourhood(string Name);
    }
}
