namespace DomainDriven.Sample.API.Feature.Product.Domain.Interfaces
{
    public interface IProduct
    {
        public Aggregates.Product GenerateProduct(string name, int stock, decimal price, int categoryId, Guid productAttributeId);
    }
}
