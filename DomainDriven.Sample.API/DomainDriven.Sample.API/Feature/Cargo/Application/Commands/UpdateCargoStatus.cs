using DomainDriven.Sample.API.Common;
using DomainDriven.Sample.API.Feature.Cargo.Application.Interfaces;
using DomainDriven.Sample.API.Feature.Cargo.Domain.Enums;
using MediatR;

namespace DomainDriven.Sample.API.Feature.Cargo.Application.Commands
{
    public class UpdateCargoStatusRequest : IRequest<Result<NoContentDto>>
    {
        public int CargoId { get; set; }
        public CargoStatus CargoStatus { get; set; }
    }
    public class UpdateCargoStatusRequestHandler() : IRequestHandler<UpdateCargoStatusRequest, Result<NoContentDto>>
    {
        public async Task<Result<NoContentDto>> Handle(UpdateCargoStatusRequest request, CancellationToken cancellationToken)
        {
            
            //var getCargo = await cargoDbContext.CargoInformation.FindAsync(request.CargoId);
            //getCargo.UpdateCargoStatus(request.CargoStatus);
            //await cargoDbContext.SaveChangesAsync(cancellationToken);
            return Result<NoContentDto>.Success();
        }
    }
}
