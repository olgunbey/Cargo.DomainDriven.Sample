using DomainDriven.Sample.API.Common;

namespace DomainDriven.Sample.API.Feature.Cargo.Domain.Events
{
    public record AddProductEvent(IEnumerable<(Guid Id, string Name)> Products, Guid CargoId) : ICustomizeNotification
    {
        public bool ShouldLogEvent { get; set; }
    }
}
