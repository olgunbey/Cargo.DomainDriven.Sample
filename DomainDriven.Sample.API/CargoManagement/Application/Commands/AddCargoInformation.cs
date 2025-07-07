using DomainDriven.Sample.API.CargoManagement.Application.Dtos;
using DomainDriven.Sample.API.CargoManagement.Domain.Aggregates;
using DomainDriven.Sample.API.CargoManagement.Domain.Repositories;
using DomainDriven.Sample.API.Database;
using MediatR;

namespace DomainDriven.Sample.API.CargoManagement.Application.Commands
{
    public class AddCargoInformationRequest : IRequest<bool>
    {
        public AddCargoInformationRequestDto AddCargoInformationRequestDto { get; set; }
    }
    public class AddCargoInformationHandler(ICargoInformation cargoInformation, IApplicationDbContext cargoInformationDbContext) : IRequestHandler<AddCargoInformationRequest, bool>
    {
        public async Task<bool> Handle(AddCargoInformationRequest request, CancellationToken cancellationToken)
        {
            CargoInformation generateCargoInformation = cargoInformation.AddCargoInformation(
                  request.AddCargoInformationRequestDto.CustomerId,
                  request.AddCargoInformationRequestDto.OrderId,
                  request.AddCargoInformationRequestDto.CompanyId);

            cargoInformationDbContext.GetEntity<CargoInformation>().Add(generateCargoInformation);
            await cargoInformationDbContext.SaveChangesAsync(cancellationToken);
            throw new NotImplementedException();
        }
    }
}
