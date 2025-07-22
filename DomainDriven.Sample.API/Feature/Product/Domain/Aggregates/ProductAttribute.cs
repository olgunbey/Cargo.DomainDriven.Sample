using DomainDriven.Sample.API.Common;
using DomainDriven.Sample.API.Feature.Product.Domain.Interfaces;
using MongoDB.Bson;

namespace DomainDriven.Sample.API.Feature.Product.Domain.Aggregates
{
    public class ProductAttribute : AggregateRoot, IProductAttribute
    {
        public Guid Id { get; private set; }
        public BsonDocument Value { get; private set; }
        public ProductAttribute GenerateProductAttribute(BsonDocument value)
        {
            this.Id = Guid.NewGuid();
            this.Value = value;
            return this;
        }
    }
}
