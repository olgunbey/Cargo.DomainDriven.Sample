using DomainDriven.Sample.API.Common;
using DomainDriven.Sample.API.Feature.Location.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DomainDriven.Sample.API.Feature.Location.Application.Queries.City
{
    public class GetAllCityRequest : IRequest<Result<List<ResponseDto>>>
    {
    }
    public class GetAllCityRequestHandler(ILocationDbContext locationDbContext) : IRequestHandler<GetAllCityRequest, Result<List<ResponseDto>>>
    {
        public async Task<Result<List<ResponseDto>>> Handle(GetAllCityRequest request, CancellationToken cancellationToken)
        {
            var data = await locationDbContext
                .City
                .Include(y => y.Districts)
                   .Select(city =>
                   new ResponseDto(city.Id,
                   city.Name,
                   city.Districts.Select(district => new DistrictResponse(district.Id, district.Name)).ToList())
                   ).ToListAsync();

            if (data == null)
                return Result<List<ResponseDto>>.Fail("Şehirler yok");

            return Result<List<ResponseDto>>.Success(data);
        }
    }
    public record ResponseDto(Guid CityId, string CityName, List<DistrictResponse> DistrictResponses)
    {
    }
    public record DistrictResponse(Guid DistrictId, string DistrictName)
    {

    }
}
