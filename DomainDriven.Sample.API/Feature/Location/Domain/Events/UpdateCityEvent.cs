using DomainDriven.Sample.API.Common;

namespace DomainDriven.Sample.API.Feature.Location.Domain.Events
{
    public record UpdateCityEvent(int Id, string Name) : ICustomizeNotification
    {
        public bool ShouldLogEvent { get; set; }
    }
}
