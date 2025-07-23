using DomainDriven.Sample.API.Common;
using DomainDriven.Sample.API.Feature.Cargo.Application.Interfaces;
using DomainDriven.Sample.API.Feature.Cargo.Domain.Aggregates;
using DomainDriven.Sample.API.Feature.Cargo.Domain.Enums;
using MediatR;

namespace DomainDriven.Sample.API.Feature.Cargo.Application.Commands
{
    public class UpdateCargoStatusRequest : IRequest<ResponseDto<NoContentDto>>
    {
        public int CargoId { get; set; }
        public CargoStatus CargoStatus { get; set; }
    }
    public class UpdateCargoStatusRequestHandler(ICargoDbContext cargoDbContext) : IRequestHandler<UpdateCargoStatusRequest, ResponseDto<NoContentDto>>
    {
        public async Task<ResponseDto<NoContentDto>> Handle(UpdateCargoStatusRequest request, CancellationToken cancellationToken)
        {
            var getCargo = await cargoDbContext.GetDbSet<CargoInformation>()
                  .FindAsync(request.CargoId);
            getCargo.UpdateCargoStatus(request.CargoStatus);
            await cargoDbContext.SaveChangesAsync(cancellationToken);
            return ResponseDto<NoContentDto>.Success();
        }
    }
}
