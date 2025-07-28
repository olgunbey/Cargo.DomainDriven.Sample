using DomainDriven.Sample.API.Common;
using DomainDriven.Sample.API.Feature.Cargo.Domain.Enums;

namespace DomainDriven.Sample.API.Feature.Cargo.Domain.Events
{
    public record UpdateCargoStatusEvent(CargoStatus CargoStatus, DateTime UpdatedDateTime, string CargoCode, int OrderId) : ICustomizeNotification
    {
        public bool ShouldLogEvent { get; set; }
    }
}
