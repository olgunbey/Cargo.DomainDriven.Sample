using DomainDriven.Sample.API.Location.Domain.Entities;

namespace DomainDriven.Sample.API.Location.Domain.Repositories
{
    public interface IDistrict
    {
        public District GenerateDistrict(string name);
    }
}
