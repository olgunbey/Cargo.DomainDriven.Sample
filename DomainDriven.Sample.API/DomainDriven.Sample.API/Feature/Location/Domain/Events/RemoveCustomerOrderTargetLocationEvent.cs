using DomainDriven.Sample.API.Common;

namespace DomainDriven.Sample.API.Feature.Location.Domain.Events
{
    public record RemoveCustomerOrderTargetLocationEvent(Guid LocationId) : ICustomizeNotification
    {
        public bool ShouldLogEvent { get; set; }
    }
}
