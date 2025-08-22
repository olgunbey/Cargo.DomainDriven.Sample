using DomainDriven.Sample.API.Common;
using DomainDriven.Sample.API.Feature.Product.Application.Dtos;
using DomainDriven.Sample.API.Feature.Product.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DomainDriven.Sample.API.Feature.Product.Application.Queries
{
    public class GetAllCategoryRequest : IRequest<Result<List<GetAllCategoryDto>>>
    {
    }
    public class GetAllCategoryRequestHandler(IProductDbContext productDbContext) : IRequestHandler<GetAllCategoryRequest, Result<List<GetAllCategoryDto>>>
    {
        public async Task<Result<List<GetAllCategoryDto>>> Handle(GetAllCategoryRequest request, CancellationToken cancellationToken)
        {
            var responseData = await productDbContext.Category
                .Select(c => new GetAllCategoryDto(c.Id, c.CategoryName)).ToListAsync();

            if (responseData.Any())
                return Result<List<GetAllCategoryDto>>.Success(responseData, 200);

            return Result<List<GetAllCategoryDto>>.Fail("No categories found", 401);
        }
    }
}
