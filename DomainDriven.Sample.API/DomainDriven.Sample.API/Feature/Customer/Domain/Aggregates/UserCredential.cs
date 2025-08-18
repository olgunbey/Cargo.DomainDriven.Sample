using DomainDriven.Sample.API.Common;
using DomainDriven.Sample.API.Feature.Customer.Domain.Events;

namespace DomainDriven.Sample.API.Feature.Customer.Domain.Aggregates
{
    public class UserCredential : AggregateRoot
    {
        public UserCredential()
        {

        }
        public UserCredential(string mail, string password, string name, string surname, bool gender)
        {
            this.Mail = mail;
            this.Password = password;
            RaiseDomainEvent(new CreateUserCredentialEvent(this.Id, name, surname, password, gender));
        }
        public string Mail { get; private set; }
        public string Password { get; private set; }

    }
}
