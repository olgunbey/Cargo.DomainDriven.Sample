using DomainDriven.Sample.API.Common;
using DomainDriven.Sample.API.Feature.Product.Domain.Interfaces;

namespace DomainDriven.Sample.API.Feature.Product.Domain.Aggregates
{
    public class Product : AggregateRoot, IProduct
    {
        public string Name { get; private set; }
        public int Stock { get; private set; }
        public decimal Price { get; private set; }
        public int CategoryId { get; private set; }
        public Guid ProductAttributeId { get; private set; } //BsonDocument olarak MongoDb'de tutulacak

        public Product GenerateProduct(string name, int stock, decimal price, int categoryId, Guid productAttributeId)
        {
            this.Name = name;
            this.Stock = stock;
            this.Price = price;
            this.CategoryId = categoryId;
            this.ProductAttributeId = productAttributeId;
            return this;
        }
    }
}
