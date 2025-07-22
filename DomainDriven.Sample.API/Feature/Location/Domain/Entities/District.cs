using DomainDriven.Sample.API.Common;

namespace DomainDriven.Sample.API.Feature.Location.Domain.Entities
{
    public class District : IEntity
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
    }
}
