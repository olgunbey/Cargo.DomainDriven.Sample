using DomainDriven.Sample.API.Order.Application.Dtos;
using DomainDriven.Sample.API.Order.Application.IRepositories;

namespace DomainDriven.Sample.API.Order.ACL
{
    public class LocationApiClient(IRedisService redisService, HttpClient httpClient) : ILocationApiClient
    {
        public async Task<LocationApiResponse> GetLocationById(int cityId, int districtId)
        {
            var cacheData = await redisService.GetAsync<LocationCacheDto>("Location");

            if (cacheData.CityDto != null)
            {
                var city = cacheData.CityDto.Find(c => c.CityId == cityId);

                var district = city!.Districts.Find(d => d.Id == districtId);

                return new LocationApiResponse(city.CityName, district!.Name);
            }
            else
            {
                return await httpClient.GetFromJsonAsync<LocationApiResponse>($"api/location/locationInformation?cityId?={cityId}&districtId={districtId}");
            }
        }
    }
}
