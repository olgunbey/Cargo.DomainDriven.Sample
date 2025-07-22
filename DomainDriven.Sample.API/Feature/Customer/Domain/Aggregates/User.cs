using DomainDriven.Sample.API.Common;

namespace DomainDriven.Sample.API.Feature.Customer.Domain.Aggregates
{
    public class User : AggregateRoot
    {
        public string Name { get; private set; }
        public string Surname { get; private set; }
        public bool Gender { get; private set; }
        public int UserCredentialsId { get; private set; }
    }
}
