using DomainDriven.Sample.API.Common;
using DomainDriven.Sample.API.Feature.Customer.Domain.Interfaces;

namespace DomainDriven.Sample.API.Feature.Customer.Domain.Aggregates
{
    public class UserCredentials : AggregateRoot, IUserCredentials
    {
        public string Mail { get; private set; }
        public string Password { get; private set; }

        public UserCredentials Register(string mail, string password)
        {
            this.Mail = mail;
            this.Password = password;
            return this;
        }
    }
}
