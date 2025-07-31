using DomainDriven.Sample.API.Feature.Location.Application.Interfaces;
using DomainDriven.Sample.API.Feature.Location.Domain.Events.District;
using MediatR;
using MongoDB.Driver.Linq;

namespace DomainDriven.Sample.API.Feature.Location.Application.DomainEventHandlers.District
{
    public class UpdateDistrictEventHandler(ILocationReadModelDbContext locationReadModelDbContext) : INotificationHandler<UpdateDistrictEvent>
    {
        public async Task Handle(UpdateDistrictEvent notification, CancellationToken cancellationToken)
        {
            var getDistrict = await locationReadModelDbContext.DistrictReadModel.SingleAsync(y => y.Id == notification.DistrictId);
            getDistrict.Name = notification.DistrictName;
            await locationReadModelDbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
