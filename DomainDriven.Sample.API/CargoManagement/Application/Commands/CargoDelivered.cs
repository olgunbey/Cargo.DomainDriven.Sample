using DomainDriven.Sample.API.CargoManagement.Domain.Aggregates;
using DomainDriven.Sample.API.CargoManagement.Domain.ValueObjects;
using EventStore.Client;
using MediatR;
using System.Text.Json;

namespace DomainDriven.Sample.API.CargoManagement.Application.Commands
{
    public class CargoDeliveredRequest : IRequest<bool>
    {
        public string CargoCode { get; set; }
        public int EmployeeId { get; set; }
    }
    public class CargoDeliveredHandler(EventStoreClient eventStoreClient) : IRequestHandler<CargoDeliveredRequest, bool>
    {
        public async Task<bool> Handle(CargoDeliveredRequest request, CancellationToken cancellationToken)
        {
            var result = await eventStoreClient.ReadStreamAsync(
                  Direction.Backwards,
                  streamName: $"Cargo-{request.CargoCode}",
                  revision: StreamPosition.End,
                  maxCount: 1).SingleAsync();

            if (result.Event == null || result.Event.Data.Length == 0)
            {
                throw new Exception("");
            }

            var lastEvent = JsonSerializer.Deserialize<CargoInformation>(result.Event.Data.ToArray())!;

            var lastEventCopy = lastEvent.ShallowCopy();

            lastEventCopy.UpdateStatus(StatusType.Delivered);

            var @event = new EventData(Uuid.NewUuid(), typeof(CargoInformation).Name, JsonSerializer.SerializeToUtf8Bytes(lastEventCopy));


            await eventStoreClient.AppendToStreamAsync(
                 streamName: $"Cargo-{request.CargoCode}",
                 expectedState: StreamState.Any,
                 eventData: [@event],
                 cancellationToken: cancellationToken);

            return true;
        }
    }
}
