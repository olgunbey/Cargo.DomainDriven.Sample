using DomainDriven.Sample.API.Common;

namespace DomainDriven.Sample.API.Feature.Customer.Domain.Aggregates
{
    public class UserCredential : AggregateRoot
    {
        public UserCredential()
        {

        }
        public UserCredential(string mail,string password)
        {
            this.Mail = mail;
            this.Password = password;
        }
        public string Mail { get; private set; }
        public string Password { get; private set; }

    }
}
