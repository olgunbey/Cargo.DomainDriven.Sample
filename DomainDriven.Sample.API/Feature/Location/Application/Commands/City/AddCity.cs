using DomainDriven.Sample.API.Common;
using DomainDriven.Sample.API.Feature.Location.Application.Dtos;
using DomainDriven.Sample.API.Feature.Location.Application.Interfaces;
using DomainDriven.Sample.API.Feature.Location.Domain.Interfaces;
using MediatR;

namespace DomainDriven.Sample.API.Feature.Location.Application.Commands.City
{
    public class AddCityRequest : IRequest<ResponseDto<NoContentDto>>
    {
        public string CityName { get; set; }
    }
    public class AddCityRequestHandler(ILocationDbContext locationDbContext, ICity city, ICacheRepository cacheRepository) : IRequestHandler<AddCityRequest, ResponseDto<NoContentDto>>
    {
        public async Task<ResponseDto<NoContentDto>> Handle(AddCityRequest request, CancellationToken cancellationToken)
        {
            var generateCity = city.AddCity(request.CityName);
            await locationDbContext.City.AddAsync(generateCity);
            await locationDbContext.SaveChangesAsync(cancellationToken);

            var locationCacheDto = new LocationCacheDto()
            {
                Id = generateCity.Id,
                CityName = generateCity.Name
            };

            var cache = await cacheRepository.GetCache<List<LocationCacheDto>>("LocationCache");
            if (cache == null)
            {
                cache = new();
            }
            cache.Add(locationCacheDto);
            await cacheRepository.SetCache("LocationCache", cache);

            return ResponseDto<NoContentDto>.Success();
        }
    }
}
