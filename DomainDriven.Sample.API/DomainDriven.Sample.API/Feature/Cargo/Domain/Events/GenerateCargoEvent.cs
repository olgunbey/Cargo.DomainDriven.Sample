using DomainDriven.Sample.API.Common;

namespace DomainDriven.Sample.API.Feature.Cargo.Domain.Events
{
    public record GenerateCargoEvent(int CompanyId,
        Guid CargoId,
        Guid OrderId,
        DateTime EstimatedDateTime,
        DateTime CreatedDate,
        string CargoCode,
        Guid CityId,
        string CityName,
        Guid DistrictId,
        string DistrictName,
        Dictionary<Guid,string> Products,
        string Detail
        ) : ICustomizeNotification
    {
        public bool ShouldLogEvent { get; set; }
    }
}
