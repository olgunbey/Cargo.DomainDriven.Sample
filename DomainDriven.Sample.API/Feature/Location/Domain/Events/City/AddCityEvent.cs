using DomainDriven.Sample.API.Common;

namespace DomainDriven.Sample.API.Feature.Location.Domain.Events.City
{
    public record AddCityEvent(string cityName, Guid Id) : ICustomizeNotification
    {
        public bool ShouldLogEvent { get; set; }
    }
}
