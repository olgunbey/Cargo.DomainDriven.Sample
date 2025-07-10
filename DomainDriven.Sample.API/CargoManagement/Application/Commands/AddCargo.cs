using DomainDriven.Sample.API.CargoManagement.Application.Dtos;
using DomainDriven.Sample.API.CargoManagement.Application.IRepositories;
using DomainDriven.Sample.API.CargoManagement.Domain.Aggregates;
using DomainDriven.Sample.API.CargoManagement.Infrastructure.EventStore;
using EventStore.Client;
using MediatR;

namespace DomainDriven.Sample.API.CargoManagement.Application.Commands
{
    public class AddCargoRequest : IRequest<bool>
    {
        public AddCargoRequestDto AddCargoRequestDto { get; set; }
    }
    public class AddCargoRequestHandler(ICargo cargo, EventStoreClient eventStoreClient) : IRequestHandler<AddCargoRequest, bool>
    {
        public async Task<bool> Handle(AddCargoRequest request, CancellationToken cancellationToken)
        {
            CargoInformation cargoInformation = cargo.GenerateCargo(
                 request.AddCargoRequestDto.CustomerId,
                 request.AddCargoRequestDto.OrderId,
                 request.AddCargoRequestDto.CompanyId,
                 request.AddCargoRequestDto.CityId,
                 request.AddCargoRequestDto.DistrictId,
                 request.AddCargoRequestDto.Detail);

            var @event = new CargoGeneratedEvent(cargoInformation.CargoCode, cargoInformation.EmployeeId, cargoInformation.CustomerId);

            var eventData = new EventData(
                Uuid.NewUuid(),
                typeof(CargoGeneratedEvent).Name,
                System.Text.Json.JsonSerializer.SerializeToUtf8Bytes(@event));

            await eventStoreClient.AppendToStreamAsync(
                 streamName: $"Cargo-{cargoInformation.CargoCode}",
                 expectedState: StreamState.Any,
                 eventData: [eventData]);

            return true;
        }
    }
}
