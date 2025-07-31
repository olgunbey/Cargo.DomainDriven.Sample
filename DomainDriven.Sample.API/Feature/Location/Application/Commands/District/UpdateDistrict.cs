using DomainDriven.Sample.API.Common;
using DomainDriven.Sample.API.Feature.Location.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DomainDriven.Sample.API.Feature.Location.Application.Commands.District
{
    public class UpdateDistrictRequest : IRequest<ResponseDto<NoContentDto>>
    {
        public Guid CityId { get; set; }
        public Guid DistrictId { get; set; }
        public string DistrictName { get; set; }
    }
    public class UpdateDistrictRequestHandler(ILocationDbContext locationDbContext) : IRequestHandler<UpdateDistrictRequest, ResponseDto<NoContentDto>>
    {
        public async Task<ResponseDto<NoContentDto>> Handle(UpdateDistrictRequest request, CancellationToken cancellationToken)
        {
            var cityDbSet = locationDbContext.GetDbSet<Domain.Aggregates.City>();

            var getCity = await cityDbSet.SingleAsync(y => y.Id == request.CityId);


            
            throw new NotImplementedException();
        }
    }
}
