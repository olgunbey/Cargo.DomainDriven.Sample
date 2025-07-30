using DomainDriven.Sample.API.Common;

namespace DomainDriven.Sample.API.Feature.Location.Domain.Entities
{
    public class District : IEntity
    {
        public District(string name)
        {
            Name = name;
        }
        public int Id { get; private set; }
        public string Name { get; private set; }
    }
}
