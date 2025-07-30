using DomainDriven.Sample.API.Common;
using DomainDriven.Sample.API.Feature.Location.Application.Dtos;
using DomainDriven.Sample.API.Feature.Location.Domain.Events;
using MediatR;

namespace DomainDriven.Sample.API.Feature.Location.Application.DomainEventHandlers
{
    public class UpdateCityEventHandler(ICacheRepository cacheRepository) : INotificationHandler<UpdateCityEvent>
    {
        public async Task Handle(UpdateCityEvent notification, CancellationToken cancellationToken)
        {
            var cache = await cacheRepository.GetCache<Dictionary<int, LocationCacheDto>>("LocationCache");

            if (cache == null)
                return;

            if (cache.TryGetValue(notification.Id, out var value))
            {
                value.CityName = notification.Name;
                await cacheRepository.SetCache("LocationCache", cache);
            }
        }
    }
}
