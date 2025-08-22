using DomainDriven.Sample.API.Common;
using DomainDriven.Sample.API.Feature.Product.Application.Interfaces;
using DomainDriven.Sample.API.Feature.Product.Domain.Aggregates;
using MediatR;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;
using MongoDB.Driver;

namespace DomainDriven.Sample.API.Feature.Product.Application.Commands.Product
{
    public class CreateProductRequest : IRequest<Result<NoContentDto>>
    {
        public string Name { get; set; }
        public int Stock { get; set; }
        public decimal Price { get; set; }
        public Guid CategoryId { get; set; }
        public string ProductAttribute { get; set; }

    }
    public class CreateProductRequestHandler(IProductDbContext productDbContext, IMongoClient mongoClient) : IRequestHandler<CreateProductRequest, Result<NoContentDto>>
    {
        public async Task<Result<NoContentDto>> Handle(CreateProductRequest request, CancellationToken cancellationToken)
        {
            //BsonSerializer.RegisterSerializer(new GuidSerializer(GuidRepresentation.Standard));
            //var bsonDocumentData = BsonDocument.Parse(request.ProductAttribute);
            //var generateProductAttribute = new ProductAttribute(bsonDocumentData);

            var mongoDatabase = mongoClient.GetDatabase("DomainDrivenSample");


            var generateProduct = new Domain.Aggregates.Product(
                 request.Name,
                request.Stock,
                request.Price,
                request.CategoryId,
                /*generateProductAttribute.Id*/
                Guid.NewGuid());

            productDbContext.Product.Add(generateProduct);
            await productDbContext.SaveChangesAsync(cancellationToken);
            //using (var session = await mongoClient.StartSessionAsync())
            //{
            //    session.StartTransaction();
            //    try
            //    {
            //        await mongoDatabase.GetCollection<ProductAttribute>("ProductAttribute")
            //     .InsertOneAsync(generateProductAttribute);

            //        await productDbContext.SaveChangesAsync(cancellationToken);
            //        await session.CommitTransactionAsync();
            //    }
            //    catch (Exception e)
            //    {
            //        await session.AbortTransactionAsync();
            //        return ResponseDto<NoContentDto>.Fail("Hata!!");
            //    }
            //}
            return Result<NoContentDto>.Success(201);
        }
    }
}
