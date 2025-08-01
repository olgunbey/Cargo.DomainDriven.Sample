using DomainDriven.Sample.API.Feature.Location.Application.Interfaces;
using DomainDriven.Sample.API.Feature.Location.Domain.Events.District;
using DomainDriven.Sample.API.Feature.Location.Domain.ReadModel;
using MediatR;

namespace DomainDriven.Sample.API.Feature.Location.Application.DomainEventHandlers.District
{
    public class AddDistrictEventHandler(ILocationReadModelDbContext locationReadModelDbContext) : INotificationHandler<AddDistrictEvent>
    {
        public async Task Handle(AddDistrictEvent notification, CancellationToken cancellationToken)
        {

            locationReadModelDbContext.DistrictReadModel.Add(new DistrictReadModel
            {
                Id = notification.Id,
                CityId = notification.CityId,
                Name = notification.DistrictName
            });

            await locationReadModelDbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
