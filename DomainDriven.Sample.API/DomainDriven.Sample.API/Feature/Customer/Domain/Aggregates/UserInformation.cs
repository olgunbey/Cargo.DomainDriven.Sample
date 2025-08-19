using DomainDriven.Sample.API.Common;
using DomainDriven.Sample.API.Feature.Customer.Domain.Events;

namespace DomainDriven.Sample.API.Feature.Customer.Domain.Aggregates
{
    public class UserInformation : AggregateRoot
    {
        public UserInformation()
        {

        }
        public UserInformation(string name, string surname, bool gender, string mail, string password)
        {
            this.Name = name;
            this.Surname = surname;
            this.Gender = gender;
            RaiseDomainEvent(new RegisterUserEvent(mail, password));
        }
        public string Name { get; private set; }
        public string Surname { get; private set; }
        public bool Gender { get; private set; }

    }
}
