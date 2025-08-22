using DomainDriven.Sample.API.Common;
using DomainDriven.Sample.API.Feature.Location.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DomainDriven.Sample.API.Feature.Location.Application.Queries.Location
{
    public class GetAllSaveLocationForOrderRequest(Guid customerId) : IRequest<Result<List<ResponseDto>>>
    {
        public Guid CustomerId => customerId;
    }
    public class GetAllSaveLocationForOrderRequestHandler(ILocationDbContext locationDbContext) : IRequestHandler<GetAllSaveLocationForOrderRequest, Result<List<ResponseDto>>>
    {
        public async Task<Result<List<ResponseDto>>> Handle(GetAllSaveLocationForOrderRequest request, CancellationToken cancellationToken)
        {
            var responseData = await locationDbContext.CustomerOrderTargetLocationReadModel
                 .Select(y => new ResponseDto
                 {
                     Id = y.Id,
                     CityName = y.CityName,
                     DistrictName = y.DistrictName,
                     Detail = y.LocationHeader,
                     LocationHeader = y.LocationHeader,
                     CustomerId = y.CustomerId,
                 })
                 .Where(y => y.CustomerId == request.CustomerId)
                 .ToListAsync();

            return Result<List<ResponseDto>>.Success(responseData);
        }
    }
    public class ResponseDto
    {
        public Guid Id { get; set; }
        public Guid CustomerId { get; set; }
        public string LocationHeader { get; set; }
        public string CityName { get; set; }
        public string DistrictName { get; set; }
        public string Detail { get; set; }
    }
}
