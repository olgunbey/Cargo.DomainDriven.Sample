using DomainDriven.Sample.API.Feature.Product.Domain.Aggregates;
using MongoDB.Bson;

namespace DomainDriven.Sample.API.Feature.Product.Domain.Interfaces
{
    public interface IProductAttribute
    {
        ProductAttribute GenerateProductAttribute(BsonDocument bsonElements);

    }
}
