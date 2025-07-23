using DomainDriven.Sample.API.Common;
using DomainDriven.Sample.API.Feature.Product.Application.Dtos;
using DomainDriven.Sample.API.Feature.Product.Application.Interfaces;
using DomainDriven.Sample.API.Feature.Product.Domain.Aggregates;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;
using ServiceStack;

namespace DomainDriven.Sample.API.Feature.Product.Application.Queries
{
    public class GetAllProductByCategoryIdRequest : IRequest<ResponseDto<List<GetAllProductByCategoryIdDto>>>
    {
        public int CategoryId { get; set; }
    }
    public class GetAllProductByCategoryIdRequestHandler(IProductDbContext productDbContext, IMongoClient mongoClient) : IRequestHandler<GetAllProductByCategoryIdRequest, ResponseDto<List<GetAllProductByCategoryIdDto>>>
    {
        public async Task<ResponseDto<List<GetAllProductByCategoryIdDto>>> Handle(GetAllProductByCategoryIdRequest request, CancellationToken cancellationToken)
        {
            var mongoDatabase = mongoClient.GetDatabase("DomainDrivenSample");

            var getAllProductByCategoryId = await productDbContext.GetDbSet<Domain.Aggregates.Product>()
                   .Where(x => x.CategoryId == request.CategoryId)
                   .ToListAsync();

            var query = Builders<ProductAttribute>.Filter.In(y => y.Id, getAllProductByCategoryId.Select(y => y.ProductAttributeId).ToList());

            var mongoProductAttributes = (await mongoDatabase.GetCollection<ProductAttribute>("ProductAttribute")
                 .FindAsync(query)).ToList();

            var response = getAllProductByCategoryId.Select(y => new GetAllProductByCategoryIdDto()
            {
                Name = y.Name,
                Price = y.Price,
                ProductAttribute = mongoProductAttributes.Single(x => x.Id == y.ProductAttributeId).Value
            }).ToList();

            return ResponseDto<List<GetAllProductByCategoryIdDto>>.Success(response);

        }
    }
}
