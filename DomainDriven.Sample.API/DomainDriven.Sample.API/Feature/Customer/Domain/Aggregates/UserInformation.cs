using DomainDriven.Sample.API.Common;

namespace DomainDriven.Sample.API.Feature.Customer.Domain.Aggregates
{
    public class UserInformation : AggregateRoot
    {
        public UserInformation()
        {

        }
        public UserInformation(string name, string surname, bool gender, Guid userCredentialsId)
        {
            this.Name = name;
            this.Surname = surname;
            this.Gender = gender;
            UserCredentialsId = userCredentialsId;
        }
        public string Name { get; private set; }
        public string Surname { get; private set; }
        public bool Gender { get; private set; }
        public Guid UserCredentialsId { get; private set; }

    }
}
