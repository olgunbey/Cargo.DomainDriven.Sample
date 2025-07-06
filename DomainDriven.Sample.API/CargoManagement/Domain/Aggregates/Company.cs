using DomainDriven.Sample.API.CargoManagement.Domain.Repositories;

namespace DomainDriven.Sample.API.CargoManagement.Domain.Aggregates
{
    public class Company : IAggregateRoot, ICompany
    {
        public int Id { get; private set; }
        public string Code { get; private set; }
        public string Name { get; private set; }

        public Company AddCompany(string code, string name)
        {
            this.Code = code;
            this.Name = name;
            return this;
        }
    }
}
