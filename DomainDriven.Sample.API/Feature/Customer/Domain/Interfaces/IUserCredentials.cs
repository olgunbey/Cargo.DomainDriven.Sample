using DomainDriven.Sample.API.Feature.Customer.Domain.Aggregates;

namespace DomainDriven.Sample.API.Feature.Customer.Domain.Interfaces
{
    public interface IUserCredentials
    {
        public UserCredentials Register(string mail, string password);
    }
}
