using DomainDriven.Sample.API.Common;

namespace DomainDriven.Sample.API.Feature.Location.Domain.Events.District
{
    public record UpdateDistrictEvent(Guid DistrictId, string DistrictName) : ICustomizeNotification
    {
        public bool ShouldLogEvent { get; set; }
    }
}
