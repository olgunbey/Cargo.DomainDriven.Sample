using DomainDriven.Sample.API.Feature.Location.Application.Interfaces;
using DomainDriven.Sample.API.Feature.Location.Domain.Events.City;
using DomainDriven.Sample.API.Feature.Location.Domain.ReadModel;
using MediatR;

namespace DomainDriven.Sample.API.Feature.Location.Application.DomainEventHandlers.City
{
    public class AddCityEventHandler(ILocationReadModelDbContext locationReadModelDbContext) : INotificationHandler<AddCityEvent>
    {
        public async Task Handle(AddCityEvent notification, CancellationToken cancellationToken)
        {
            locationReadModelDbContext.GetDbSet<CityReadModel>()
                .Add(new CityReadModel
                {
                    Id = notification.Id,
                    Name = notification.cityName
                });
            await locationReadModelDbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
