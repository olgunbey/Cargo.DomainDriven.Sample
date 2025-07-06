using DomainDriven.Sample.API.CargoManagement.Domain.Aggregates;

namespace DomainDriven.Sample.API.CargoManagement.Domain.Repositories
{
    public interface ICompany
    {
        public Company AddCompany(string code, string name);
    }
}
