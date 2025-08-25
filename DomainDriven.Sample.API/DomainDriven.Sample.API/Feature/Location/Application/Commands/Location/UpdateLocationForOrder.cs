using DomainDriven.Sample.API.Common;
using DomainDriven.Sample.API.Feature.Location.Application.Interfaces;
using MediatR;

namespace DomainDriven.Sample.API.Feature.Location.Application.Commands.Location
{
    public class UpdateLocationForOrderRequest : IRequest<Result<NoContentDto>>
    {
        public Guid Id { get; set; }
        public Guid CityId { get; set; }
        public Guid DistrictId { get; set; }
        public string Detail { get; set; }
    }
    public class UpdateLocationForOrderRequestHandler(ILocationDbContext locationDbContext) : IRequestHandler<UpdateLocationForOrderRequest, Result<NoContentDto>>
    {
        public async Task<Result<NoContentDto>> Handle(UpdateLocationForOrderRequest request, CancellationToken cancellationToken)
        {
            var getCustomerOrderTargetLocation = await locationDbContext.CustomerOrderTargetLocation.FindAsync(request.Id);
            getCustomerOrderTargetLocation.UpdateTargetLocation(request.CityId, request.DistrictId, request.Detail);

            await locationDbContext.SaveChangesAsync(cancellationToken);

            return Result<NoContentDto>.Success();
        }
    }
}
