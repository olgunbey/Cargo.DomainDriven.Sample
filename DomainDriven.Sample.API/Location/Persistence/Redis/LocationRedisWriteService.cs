using DomainDriven.Sample.API.Common;
using DomainDriven.Sample.API.Location.Application.Dtos;
using DomainDriven.Sample.API.Location.Application.IRepositories;
using DomainDriven.Sample.API.Location.Domain.Aggregates;
using Microsoft.EntityFrameworkCore;
using ServiceStack.Redis;

namespace DomainDriven.Sample.API.Location.Persistence.Redis
{
    public class LocationRedisWriteService(IRedisClientsManagerAsync redisClientsManagerAsync, ILocationDbContext locationDbContext) : IWriteRedisService<City>
    {
        public async Task AddOrUpdate(string key)
        {
            await using (var redisClient = await redisClientsManagerAsync.GetClientAsync())
            {
                DbSet<City> dbCities = locationDbContext.GetDbSet<City>();

                var queryData = dbCities.Include(y => y.Districts)
                                        .AsNoTrackingWithIdentityResolution();

                var locationCacheDto = new LocationCacheDto
                {
                    CityDtos = await queryData.Select(y => new CityDto
                    {
                        CityId = y.Id,
                        CityName = y.Name,
                        Districts = y.Districts.Select(d => new DistrictDto
                        {
                            Id = d.Id,
                            Name = d.Name
                        }).ToList()
                    }).ToListAsync()
                };

                await redisClient.AddAsync("Location-City", locationCacheDto);
            }
        }
    }
}
