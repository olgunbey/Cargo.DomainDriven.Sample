using DomainDriven.Sample.API.Common;
using DomainDriven.Sample.API.Feature.Product.Domain.Events.Product;

namespace DomainDriven.Sample.API.Feature.Product.Domain.Aggregates
{
    public class Product : AggregateRoot
    {
        public Product(string name, int stock, decimal price, Guid categoryId, Guid productAttributeId)
        {
            this.Name = name;
            this.Stock = stock;
            this.Price = price;
            this.CategoryId = categoryId;
            this.ProductAttributeId = productAttributeId;
        }
        public string Name { get; private set; }
        public int Stock { get; private set; }
        public decimal Price { get; private set; }
        public Guid CategoryId { get; private set; }
        public Guid ProductAttributeId { get; private set; } //BsonDocument olarak MongoDb'de tutulacak


        public void UpdateProduct(string name, int stock, decimal price)
        {
            this.Name = name;
            this.Stock = stock;
            this.Price = price;
            RaiseDomainEvent(new UpdateProductEvent(this.Id, name, stock, price));
        }

    }
}
