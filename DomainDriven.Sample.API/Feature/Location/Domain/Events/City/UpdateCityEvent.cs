using DomainDriven.Sample.API.Common;

namespace DomainDriven.Sample.API.Feature.Location.Domain.Events.City
{
    public record UpdateCityEvent(Guid Id, string Name) : ICustomizeNotification
    {
        public bool ShouldLogEvent { get; set; }
    }
}
