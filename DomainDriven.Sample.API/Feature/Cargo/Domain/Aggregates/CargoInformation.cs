using DomainDriven.Sample.API.Common;
using DomainDriven.Sample.API.Feature.Cargo.Domain.Enums;

namespace DomainDriven.Sample.API.Feature.Cargo.Domain.Aggregates
{
    public class CargoInformation : AggregateRoot
    {
        public int CompanyId { get; private set; }
        public int OrderId { get; private set; }
        public CargoStatus CargoStatus { get; private set; }
        public string CargoCode { get; private set; }
        public DateTime EstimateDateTime { get; private set; }
    }
}
