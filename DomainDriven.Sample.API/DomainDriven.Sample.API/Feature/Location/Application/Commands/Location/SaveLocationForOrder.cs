using DomainDriven.Sample.API.Common;
using DomainDriven.Sample.API.Feature.Location.Application.Interfaces;
using DomainDriven.Sample.API.Feature.Location.Domain.Aggregates;
using MediatR;

namespace DomainDriven.Sample.API.Feature.Location.Application.Commands.Location
{
    public class SaveLocationForOrderRequest : IRequest<Result<NoContentDto>>
    {
        public Guid CustomerId { get; set; }
        public Guid CityId { get; set; }
        public string LocationHeader { get; set; }
        public Guid DistrictId { get; set; }
        public string Detail { get; set; }
    }
    public class SaveLocationForOrderRequestHandler(ILocationDbContext locationDbContext) : IRequestHandler<SaveLocationForOrderRequest, Result<NoContentDto>>
    {
        public async Task<Result<NoContentDto>> Handle(SaveLocationForOrderRequest request, CancellationToken cancellationToken)
        {
            var customOrderTargetLocation = new CustomerOrderTargetLocation(request.LocationHeader, request.CustomerId, request.CityId, request.DistrictId, request.Detail);
            customOrderTargetLocation.CreateLocation();
            locationDbContext.CustomerOrderTargetLocation.Add(customOrderTargetLocation);
            await locationDbContext.SaveChangesAsync(cancellationToken);
            return Result<NoContentDto>.Success(201);
        }
    }
}
