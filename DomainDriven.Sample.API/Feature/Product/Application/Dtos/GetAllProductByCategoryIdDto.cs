using MongoDB.Bson;

namespace DomainDriven.Sample.API.Feature.Product.Application.Dtos
{
    public class GetAllProductByCategoryIdDto
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public BsonDocument ProductAttribute { get; set; }
    }
}
