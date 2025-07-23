using DomainDriven.Sample.API.Common;

namespace DomainDriven.Sample.API.Feature.Cargo.Domain.Aggregates
{
    public class OutboxCargoTable : AggregateRoot
    {
        public DateTime ProcessedDate { get; private set; }
        public string Payload { get; private set; }
        public string Type { get; set; }
    }
}
