using DomainDriven.Sample.API.Feature.Location.Application.Interfaces;
using DomainDriven.Sample.API.Feature.Location.Domain.Events.City;
using MediatR;

namespace DomainDriven.Sample.API.Feature.Location.Application.DomainEventHandlers.City
{
    public class UpdateCityEventHandler(ILocationReadModelDbContext locationReadModelDbContext) : INotificationHandler<UpdateCityEvent>
    {
        public async Task Handle(UpdateCityEvent notification, CancellationToken cancellationToken)
        {
            var getCity = await locationReadModelDbContext.CityReadModel.FindAsync(notification.Id);

            if (getCity == null)
                return;

            getCity.Name = notification.Name;
            await locationReadModelDbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
