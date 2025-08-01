using DomainDriven.Sample.API.Feature.Cargo.Application.Interfaces;
using DomainDriven.Sample.API.Feature.Cargo.Domain.Events;
using DomainDriven.Sample.API.Feature.Cargo.Domain.ReadModel;
using MediatR;

namespace DomainDriven.Sample.API.Feature.Cargo.Application.DomainEventHandlers
{
    public class AddProductEventHandler(ICargoDbContext cargoDbContext) : INotificationHandler<AddProductEvent>
    {
        public async Task Handle(AddProductEvent notification, CancellationToken cancellationToken)
        {
            var cargoProductReadModels = notification.Products.Select(y => new CargoProductReadModel
            {
                CargoId = notification.CargoId,
                ProductId = y.Id,
                ProductName = y.Name,
            });
            await cargoDbContext.GetDbSet<CargoProductReadModel>()
                  .AddRangeAsync(cargoProductReadModels);

            await cargoDbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
