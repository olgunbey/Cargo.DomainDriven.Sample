using DomainDriven.Sample.API.CargoManagement.Application.Commands;
using DomainDriven.Sample.API.CargoManagement.Domain.Events;
using DomainDriven.Sample.API.CargoManagement.Infrastructure.EventStore;
using EventStore.Client;
using MediatR;
using System.Text.Json;

namespace DomainDriven.Sample.API
{
    public class CargoEventListenerService(EventStoreClient eventStoreClient, IMediator mediator) : BackgroundService
    {
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            await eventStoreClient.SubscribeToAllAsync(FromAll.Start, async (subscription, resolvedEvent, ct) =>
             {
                 var type = resolvedEvent.Event.EventType;
                 var data = resolvedEvent.Event.Data.ToArray();

                 switch (type)
                 {
                     case nameof(CargoGeneratedEvent):
                         await mediator.Send(new CargoReadModelGenerateRequest() { CargoGeneratedEvent = JsonSerializer.Deserialize<CargoGeneratedEvent>(data) });
                         break;
                     case nameof(CargoInTransitEvent):
                         await mediator.Send(new CargoReadModelInTransitRequest()
                         {
                             CargoCode = JsonSerializer.Deserialize<CargoInTransitEvent>(data).CargoCode
                         });
                         break;
                     case nameof(CargoDeliveredEvent):
                         await mediator.Send(new CargoReadModelDeliveredRequest()
                         {
                             CargoCode = JsonSerializer.Deserialize<CargoDeliveredEvent>(data).CargoCode
                         });
                         break;
                     case nameof(CargoCancelledEvent):
                     default:
                         break;
                 }
             });
        }
    }
}
