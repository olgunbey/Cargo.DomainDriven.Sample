using DomainDriven.Sample.API.Common;

namespace DomainDriven.Sample.API.Feature.Product.Domain.Aggregates
{
    public class Product : AggregateRoot
    {
        public string Name { get; private set; }
        public int Stock { get; private set; }
        public decimal Price { get; private set; }
        public int CategoryId { get; private set; }
        public int ProductAttributeId { get; private set; } //BsonDocument olarak MongoDb'de tutulacak

    }
}
