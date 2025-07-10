
using DomainDriven.Sample.API.CargoManagement.Application.Events;
using EventStore.Client;

namespace DomainDriven.Sample.API
{
    public class CargoEventListenerService(EventStoreClient eventStoreClient) : BackgroundService
    {
        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            eventStoreClient.SubscribeToAllAsync(FromAll.Start, async (subscription, resolvedEvent, ct) =>
            {
                var type = resolvedEvent.Event.EventType;
                var data = resolvedEvent.Event.Data.ToArray();

                switch (type)
                {
                    case nameof(CargoGeneratedEvent):
                        break;
                    case nameof(CargoInTransitEvent):
                        break;
                    case nameof(CargoDeliveredEvent):
                        break;
                    case nameof(CargoCancelledEvent):
                    default:
                        break;
                }
            });
            throw new NotImplementedException();
        }
    }
}
