using DomainDriven.Sample.API.Common;
using DomainDriven.Sample.API.Feature.Product.Application.Interfaces;
using MediatR;

namespace DomainDriven.Sample.API.Feature.Product.Application.Commands.Category
{
    public class CreateCategoryRequest : IRequest<Result<NoContentDto>>
    {
        public string CategoryName { get; set; }
        public string ProductAttributeSchema { get; set; }
    }
    public class CreateCategoryRequestHandler(IProductDbContext productDbContext) : IRequestHandler<CreateCategoryRequest, Result<NoContentDto>>
    {
        async Task<Result<NoContentDto>> IRequestHandler<CreateCategoryRequest, Result<NoContentDto>>.Handle(CreateCategoryRequest request, CancellationToken cancellationToken)
        {
            var generateCategory = new Domain.Aggregates.Category(request.CategoryName, request.ProductAttributeSchema);
            productDbContext.Category.Add(generateCategory);
            await productDbContext.SaveChangesAsync(cancellationToken);
            return Result<NoContentDto>.Success();
        }
    }
}
