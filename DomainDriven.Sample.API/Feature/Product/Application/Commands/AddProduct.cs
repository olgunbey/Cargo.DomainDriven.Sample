using DomainDriven.Sample.API.Common;
using DomainDriven.Sample.API.Feature.Product.Application.Interfaces;
using DomainDriven.Sample.API.Feature.Product.Domain.Aggregates;
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
    public class AddProductRequestHandler(IProductDbContext productDbContext, IMongoClient mongoClient) : IRequestHandler<AddProductRequest, ResponseDto<NoContentDto>>
    {
        public async Task<ResponseDto<NoContentDto>> Handle(AddProductRequest request, CancellationToken cancellationToken)
        {
            var generateProductAttribute = new ProductAttribute(request.ProductAttribute.ToBsonDocument());

            var mongoDatabase = mongoClient.GetDatabase("DomainDrivenSample");

            await mongoDatabase.GetCollection<ProductAttribute>("ProductAttribute")
                 .InsertOneAsync(generateProductAttribute);

            var generateProduct = new Domain.Aggregates.Product(
                 request.Name,
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
