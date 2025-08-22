using DomainDriven.Sample.API.Common;

namespace DomainDriven.Sample.API.Feature.Location.Domain.Events
{
    public record CustomerOrderTargetLocationEvent(Guid CityId,Guid DistrictId,string Detail,Guid CustomerId,string locationHeader) : ICustomizeNotification
    {
        public bool ShouldLogEvent { get; set; }
    }
}
