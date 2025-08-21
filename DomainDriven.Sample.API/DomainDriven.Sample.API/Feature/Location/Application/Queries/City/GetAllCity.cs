using DomainDriven.Sample.API.Common;
using DomainDriven.Sample.API.Feature.Location.Application.Interfaces;
using DomainDriven.Sample.API.Feature.Location.Dtos;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DomainDriven.Sample.API.Feature.Location.Application.Queries.City
{
    public class GetAllCityRequest : IRequest<ResponseDto<List<GetAllCityResponseDto>>>
    {
    }
    public class GetAllCityRequestHandler(ILocationDbContext locationDbContext) : IRequestHandler<GetAllCityRequest, ResponseDto<List<GetAllCityResponseDto>>>
    {
        public async Task<ResponseDto<List<GetAllCityResponseDto>>> Handle(GetAllCityRequest request, CancellationToken cancellationToken)
        {

            var data = await locationDbContext
                .City
                .Include(y => y.Districts)
                   .Select(city =>
                   new GetAllCityResponseDto(city.Id,
                   city.Name,
                   city.Districts.Select(district => new DistrictResponseDto(district.Id, district.Name)).ToList())
                   ).ToListAsync();

            if (data == null)
                return ResponseDto<List<GetAllCityResponseDto>>.Fail("Şehirler yok");

            return ResponseDto<List<GetAllCityResponseDto>>.Success(data);
        }
    }
}
