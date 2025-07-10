using DomainDriven.Sample.API.CargoManagement.Application.Dtos;
using DomainDriven.Sample.API.CargoManagement.Application.IRepositories;
using DomainDriven.Sample.API.CargoManagement.Domain.Aggregates;
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

            var @event = new AddCargoEventResponseDto(
                customerId: cargoInformation.CustomerId,
                status: cargoInformation.Status,
                employeeId: cargoInformation.EmployeeId ?? 0,
                orderId: cargoInformation.OrderId,
                cargoCode: cargoInformation.CargoCode,
                companyId: cargoInformation.CompanyId,
                cargoCreatedDate: cargoInformation.CargoCreatedDate,
                lastUpdatedDate: cargoInformation.LastUpdatedDate);

            var eventData = new EventData(
                Uuid.NewUuid(),
                typeof(AddCargoEventResponseDto).Name,
                System.Text.Json.JsonSerializer.SerializeToUtf8Bytes(@event));

            await eventStoreClient.AppendToStreamAsync(
                 streamName: $"Cargo-{cargoInformation.CargoCode}",
                 expectedState: StreamState.Any,
                 eventData: [eventData]);

            return true;
        }
    }
}
