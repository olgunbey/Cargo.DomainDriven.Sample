using DomainDriven.Sample.API.Common;
using DomainDriven.Sample.API.Location.Domain.Repositories;
using System.ComponentModel.DataAnnotations.Schema;

namespace DomainDriven.Sample.API.Location.Domain.Entities
{
    public class District : IEntity, IDistrict
    {
        public District()
        {
        }
        public int Id { get; private set; }
        public string Name { get; private set; }

        public District GenerateDistrict(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("District name cannot be null or empty.", nameof(name));

            this.Name = name;
            return this;
        }
    }
}
