using DomainDriven.Sample.API.Common;
using DomainDriven.Sample.API.Feature.Customer.Domain.Interfaces;

namespace DomainDriven.Sample.API.Feature.Customer.Domain.Aggregates
{
    public class UserInformation : AggregateRoot, IUserInformation
    {
        public string Name { get; private set; }
        public string Surname { get; private set; }
        public bool Gender { get; private set; }
        public int UserCredentialsId { get; private set; }

        public UserInformation GenerateUserInformation(string name, string surname, bool gender, int userCredentialsId)
        {
            this.Name = name;
            this.Surname = surname;
            this.Gender = gender;
            UserCredentialsId = userCredentialsId;
            return this;
        }
    }
}
