using DomainDriven.Sample.API.Common;
using DomainDriven.Sample.API.Feature.Location.Application.Interfaces;
using MediatR;

namespace DomainDriven.Sample.API.Feature.Location.Application.Commands.Location
{
    public class RemoveLocationForOrderRequest(Guid locationId) : IRequest<Result<NoContentDto>>
    {
        public Guid LocationId=> locationId;
    }
    public class RemoveLocationForOrderRequestHandler(ILocationDbContext locationDbContext) : IRequestHandler<RemoveLocationForOrderRequest, Result<NoContentDto>>
    {
        public async Task<Result<NoContentDto>> Handle(RemoveLocationForOrderRequest request, CancellationToken cancellationToken)
        {
            var getRemoveLocation = await locationDbContext.CustomerOrderTargetLocation.FindAsync(request.LocationId);
            getRemoveLocation.RemoveTargetLocation();
            locationDbContext.CustomerOrderTargetLocation.Remove(getRemoveLocation);
            await locationDbContext.SaveChangesAsync(cancellationToken);
            return Result<NoContentDto>.Success();
        }
    }
}
