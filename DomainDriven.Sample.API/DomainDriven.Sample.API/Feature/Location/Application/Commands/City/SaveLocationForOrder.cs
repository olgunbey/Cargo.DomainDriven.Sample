using DomainDriven.Sample.API.Common;
using DomainDriven.Sample.API.Feature.Location.Application.Interfaces;
using DomainDriven.Sample.API.Feature.Location.Domain.Aggregates;
using MediatR;

namespace DomainDriven.Sample.API.Feature.Location.Application.Commands.City
{
    public class SaveLocationForOrderRequest : IRequest<ResponseDto<NoContentDto>>
    {
        public Guid CustomerId { get; set; }
        public Guid CityId { get; set; }
        public Guid DistrictId { get; set; }
        public string Detail { get; set; }
    }
    public class SaveLocationForOrderRequestHandler(ILocationDbContext locationDbContext) : IRequestHandler<SaveLocationForOrderRequest, ResponseDto<NoContentDto>>
    {
        public async Task<ResponseDto<NoContentDto>> Handle(SaveLocationForOrderRequest request, CancellationToken cancellationToken)
        {
            var customOrderTargetLocation = new CustomerOrderTargetLocation(request.CustomerId, request.CityId, request.DistrictId, request.Detail);
            locationDbContext.CustomerOrderTargetLocation.Add(customOrderTargetLocation);
            await locationDbContext.SaveChangesAsync(cancellationToken);
            return ResponseDto<NoContentDto>.Success(201);
        }
    }
}
