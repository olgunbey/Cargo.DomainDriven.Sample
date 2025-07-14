using DomainDriven.Sample.API.Common;
using DomainDriven.Sample.API.Location.Application.Dtos;
using DomainDriven.Sample.API.Location.Application.IRepositories;
using Microsoft.EntityFrameworkCore;
using ServiceStack.Redis;

namespace DomainDriven.Sample.API.Location.Persistence.Redis
{
    public class LocationRedisService(ILocationDbContext locationDbContext, IRedisClientsManagerAsync redisClientsManagerAsync) : IWriteRedisService<List<FromLocationToOrderCacheDto>>
    {
        public async Task AddOrUpdate<T>(string key, T value)
        {
            var getAllCity = await locationDbContext.City.Include(y => y.Districts).Select(x => new FromLocationToOrderCacheDto
            {
                CityId = x.Id,
                CityName = x.Name,
                Districts = x.Districts.Select(d => new DistrictDto
                {
                    Id = d.Id,
                    Name = d.Name
                }).ToList()
            }).ToListAsync();


            await using (var cacheClient = await redisClientsManagerAsync.GetClientAsync())
            {
                await cacheClient.AddAsync($"from_city_to_location", getAllCity);

            }
        }
    }
}
