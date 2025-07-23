using DomainDriven.Sample.API.Common;
using DomainDriven.Sample.API.Feature.Cargo.Application.Interfaces;
using DomainDriven.Sample.API.Feature.Cargo.Domain.Aggregates;
using DomainDriven.Sample.API.Feature.Cargo.Domain.Interfaces;
using MediatR;

namespace DomainDriven.Sample.API.Feature.Cargo.Application.Commands
{
    public class AddCargoRequest : IRequest<ResponseDto<NoContentDto>>
    {
        public int CompanyId { get; set; }
        public int OrderId { get; set; }
        public DateTime EstimatedDateTime { get; set; }
    }
    public class AddCargoRequestHandler(ICargoInformation cargoInformation, ICargoDbContext cargoDbContext) : IRequestHandler<AddCargoRequest, ResponseDto<NoContentDto>>
    {
        public async Task<ResponseDto<NoContentDto>> Handle(AddCargoRequest request, CancellationToken cancellationToken)
        {
            var generateCargo = cargoInformation.GenerateCargo(request.CompanyId, request.EstimatedDateTime, request.OrderId);

            cargoDbContext.GetDbSet<CargoInformation>()
                .Add(generateCargo);

            await cargoDbContext.SaveChangesAsync(cancellationToken);

            return ResponseDto<NoContentDto>.Success();


        }
    }
}
