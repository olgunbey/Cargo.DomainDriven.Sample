namespace DomainDriven.Sample.API.Feature.Product.Application.Dtos
{
    public record UpdateProductDto(Guid ProductId,string ProductName,int Stock,decimal Price) { }
}
