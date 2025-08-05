using DomainDriven.Sample.API.Common;
using MongoDB.Bson;

namespace DomainDriven.Sample.API.Feature.Product.Domain.Aggregates
{
    public class ProductAttribute : AggregateRoot
    {
        public ProductAttribute(BsonDocument value)
        {
            this.Value = value;
        }
        public BsonDocument Value { get; private set; }
    }
}
