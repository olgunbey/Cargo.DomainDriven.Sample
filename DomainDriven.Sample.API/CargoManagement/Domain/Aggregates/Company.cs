using DomainDriven.Sample.API.CargoManagement.Domain.Repositories;
using DomainDriven.Sample.API.Common;
using MediatR;

namespace DomainDriven.Sample.API.CargoManagement.Domain.Aggregates
{
    public class Company : AggregateRoot, ICompany
    {
        public Company()
        {
            Notifications = new();
        }
        public int Id { get; private set; }
        public string Code { get; private set; }
        public string Name { get; private set; }
        public List<INotification> Notifications { get; set; }

        public Company AddCompany(string code, string name)
        {
            this.Code = code;
            this.Name = name;
            return this;
        }
    }
}
