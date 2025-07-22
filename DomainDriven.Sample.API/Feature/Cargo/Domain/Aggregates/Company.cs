using DomainDriven.Sample.API.Common;

namespace DomainDriven.Sample.API.Feature.Cargo.Domain.Aggregates
{
    public class Company : AggregateRoot
    {
        public string Name { get; private set; }
    }
}
