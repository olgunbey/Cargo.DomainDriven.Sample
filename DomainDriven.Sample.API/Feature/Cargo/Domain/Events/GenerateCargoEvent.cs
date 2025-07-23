using DomainDriven.Sample.API.Common;

namespace DomainDriven.Sample.API.Feature.Cargo.Domain.Events
{
    public record GenerateCargoEvent(int CompanyId, int OrderId, DateTime EstimatedDateTime, DateTime CreatedDate, string CargoCode) : ICustomizeNotification
    {
        public bool ShouldLogEvent { get; set; }
    }
}
