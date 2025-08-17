using DomainDriven.Sample.API.Common;
using DomainDriven.Sample.API.Feature.Product.Application.Dtos;
using DomainDriven.Sample.API.Feature.Product.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DomainDriven.Sample.API.Feature.Product.Application.Queries
{
    public class GetAllCategoryRequest : IRequest<ResponseDto<List<GetAllCategoryDto>>>
    {
    }
    public class GetAllCategoryRequestHandler(IProductDbContext productDbContext) : IRequestHandler<GetAllCategoryRequest, ResponseDto<List<GetAllCategoryDto>>>
    {
        public async Task<ResponseDto<List<GetAllCategoryDto>>> Handle(GetAllCategoryRequest request, CancellationToken cancellationToken)
        {
            var responseData = await productDbContext.Category
                .Select(c => new GetAllCategoryDto(c.Id, c.CategoryName)).ToListAsync();

            if (responseData.Any())
                return ResponseDto<List<GetAllCategoryDto>>.Success(responseData, 200);

            return ResponseDto<List<GetAllCategoryDto>>.Fail("No categories found", 401);
        }
    }
}
