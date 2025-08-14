using DomainDriven.Sample.API.Common;

namespace DomainDriven.Sample.API.Feature.Product.Domain.Events.Product
{
    public record UpdateProductEvent(Guid ProductId, string ProductName) : ICustomizeNotification
    {
        public bool ShouldLogEvent { get; set; }
    }
}
