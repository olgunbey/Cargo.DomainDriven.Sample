using DomainDriven.Sample.API.CargoManagement.Domain.Aggregates;

namespace DomainDriven.Sample.API.CargoManagement.Domain.Repositories
{
    public interface ICompany
    {
        public Company GenerateCompany(string code, string name);
    }
}
