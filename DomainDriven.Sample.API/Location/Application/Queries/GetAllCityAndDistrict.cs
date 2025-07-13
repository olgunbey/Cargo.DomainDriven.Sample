using DomainDriven.Sample.API.Common;
using DomainDriven.Sample.API.Location.Application.Dtos;
using DomainDriven.Sample.API.Location.Application.IRepositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DomainDriven.Sample.API.Location.Application.Queries
{
    public class GetAllCityAndDistrictRequest : IRequest<ResponseDto<List<GetAllCityAndDistrictResponseDto>>>
    {
    }
    public class GetAllCityAndDistrictRequestHandler(ILocationDbContext locationDbContext) : IRequestHandler<GetAllCityAndDistrictRequest, ResponseDto<List<GetAllCityAndDistrictResponseDto>>>
    {
        public async Task<ResponseDto<List<GetAllCityAndDistrictResponseDto>>> Handle(GetAllCityAndDistrictRequest request, CancellationToken cancellationToken)
        {
            var getAllCityAndDistrict = await locationDbContext.GetDbSet<Domain.Aggregates.City>().Select(city => new GetAllCityAndDistrictResponseDto
            {
                Id = city.Id,
                Name = city.Name,
                District = city.Districts.Select(district => new Dtos.District
                {
                    Id = district.Id,
                    Name = district.Name
                }).ToList()
            }).ToListAsync(cancellationToken);

            if (getAllCityAndDistrict.Any())
                return ResponseDto<List<GetAllCityAndDistrictResponseDto>>.Fail("No cities found", 404);


            return ResponseDto<List<GetAllCityAndDistrictResponseDto>>.Success(getAllCityAndDistrict, 200);
        }
    }
}
