using DomainDriven.Sample.API.Common;

namespace DomainDriven.Sample.API.Feature.Product.Domain.Aggregates
{
    public class Category : AggregateRoot
    {
        public Category()
        {

        }
        public Category(string categoryName, string productAttributeSchema)
        {
            this.CategoryName = categoryName;
            this.ProductAttributeSchema = productAttributeSchema;
        }
        public string CategoryName { get; private set; }
        public string ProductAttributeSchema { get; private set; }
    }
}
