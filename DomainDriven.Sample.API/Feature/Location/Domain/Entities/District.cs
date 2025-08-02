using DomainDriven.Sample.API.Common;

namespace DomainDriven.Sample.API.Feature.Location.Domain.Entities
{
    public class District : IEntity
    {
        public District()
        {

        }
        public District(string name)
        {
            Name = name;
        }
        public Guid Id { get; set; }
        public string Name { get; private set; }

        public void UpdateName(string name)
        {
            this.Name = name;
        }
    }
}
