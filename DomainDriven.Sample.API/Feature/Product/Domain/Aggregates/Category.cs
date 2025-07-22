using DomainDriven.Sample.API.Common;

namespace DomainDriven.Sample.API.Feature.Product.Domain.Aggregates
{
    public class Category : AggregateRoot
    {
        public string CategoryName { get; private set; }
        public string ProductAttributeSchema { get; private set; }
    }
}
