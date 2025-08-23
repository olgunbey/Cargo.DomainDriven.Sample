using DomainDriven.Sample.API.Common;

namespace DomainDriven.Sample.API.Feature.Location.Domain.Events
{
    public record CreateCustomerOrderTargetLocationEvent(Guid Id,Guid CityId,Guid DistrictId,string Detail,Guid CustomerId,string locationHeader) : ICustomizeNotification
    {
        public bool ShouldLogEvent { get; set; }
    }
}
