using DomainDriven.Sample.API.Common;

namespace DomainDriven.Sample.API.Feature.Location.Domain.Events.District
{
    public record AddDistrictEvent(Guid CityId, Guid Id, string DistrictName) : ICustomizeNotification
    {
        public bool ShouldLogEvent { get ; set ; }
    }
}
