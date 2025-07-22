using DomainDriven.Sample.API.Common;
using DomainDriven.Sample.API.Feature.Product.Application.Interfaces;
using DomainDriven.Sample.API.Feature.Product.Domain.Aggregates;
using DomainDriven.Sample.API.Feature.Product.Domain.Interfaces;
using MediatR;
using MongoDB.Bson;
using MongoDB.Driver;

namespace DomainDriven.Sample.API.Feature.Product.Application.Commands
{
    public class AddProductRequest : IRequest<ResponseDto<NoContentDto>>
    {
        public string Name { get; set; }
        public int Stock { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
        public string ProductAttribute { get; set; }

    }
    public class AddProductRequestHandler(IProductDbContext productDbContext, IProduct product, IMongoClient mongoClient, IProductAttribute productAttribute) : IRequestHandler<AddProductRequest, ResponseDto<NoContentDto>>
    {
        public async Task<ResponseDto<NoContentDto>> Handle(AddProductRequest request, CancellationToken cancellationToken)
        {
            var generateProductAttribute = productAttribute.GenerateProductAttribute(request.ProductAttribute.ToBsonDocument());

            var mongoDatabase = mongoClient.GetDatabase("DomainDrivenSample");

            await mongoDatabase.GetCollection<ProductAttribute>("ProductAttribute")
                 .InsertOneAsync(generateProductAttribute);

            var generateProduct = product.GenerateProduct(request.Name,
               request.Stock,
               request.Price,
               request.CategoryId,
               generateProductAttribute.Id);

            productDbContext.Product.Add(generateProduct);
            using (var session = await mongoClient.StartSessionAsync())
            {
                session.StartTransaction();
                try
                {
                    await productDbContext.SaveChangesAsync(cancellationToken);
                    await session.CommitTransactionAsync();
                }
                catch (Exception e)
                {
                    await session.AbortTransactionAsync();
                    return ResponseDto<NoContentDto>.Fail("Hata!!");
                }
            }
            return ResponseDto<NoContentDto>.Success(201);
        }
    }
}
