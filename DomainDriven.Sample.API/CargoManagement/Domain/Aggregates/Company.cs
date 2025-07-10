using DomainDriven.Sample.API.CargoManagement.Domain.Repositories;
using DomainDriven.Sample.API.Common;

namespace DomainDriven.Sample.API.CargoManagement.Domain.Aggregates
{
    public class Company : AggregateRoot, ICompany
    {
        public Company()
        {

        }
        public int Id { get; private set; }
        public string Code { get; private set; }
        public string Name { get; private set; }

        public Company GenerateCompany(string code, string name)
        {
            this.Code = code;
            this.Name = name;
            return this;
        }
    }
}
