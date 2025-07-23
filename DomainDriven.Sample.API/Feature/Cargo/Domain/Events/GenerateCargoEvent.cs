using DomainDriven.Sample.API.Common;

namespace DomainDriven.Sample.API.Feature.Cargo.Domain.Events
{
    public record GenerateCargoEvent(int CompanyId, int OrderId, DateTime EstimatedDateTime) : ICustomizeNotification
    {
        public bool ShouldLogEvent { get; set; }
    }
}
