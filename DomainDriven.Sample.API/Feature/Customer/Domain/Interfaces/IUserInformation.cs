using DomainDriven.Sample.API.Feature.Customer.Domain.Aggregates;

namespace DomainDriven.Sample.API.Feature.Customer.Domain.Interfaces
{
    public interface IUserInformation
    {
        public UserInformation GenerateUserInformation(string name, string surname, bool gender, int userCredentialsId);
    }
}
