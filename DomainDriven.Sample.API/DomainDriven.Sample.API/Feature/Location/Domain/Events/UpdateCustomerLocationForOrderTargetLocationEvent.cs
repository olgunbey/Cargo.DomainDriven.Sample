using DomainDriven.Sample.API.Common;

namespace DomainDriven.Sample.API.Feature.Location.Domain.Events
{
    public record UpdateCustomerLocationForOrderTargetLocationEvent(Guid cityId, Guid districtId, string detail, Guid id) : ICustomizeNotification
    {
        public bool ShouldLogEvent { get; set; }
    }
}
