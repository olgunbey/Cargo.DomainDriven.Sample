using DomainDriven.Sample.API.Common;
using DomainDriven.Sample.API.Feature.Location.Application.Interfaces;
using MediatR;

namespace DomainDriven.Sample.API.Feature.Location.Application.Commands.District
{
    public class AddDistrictRequest : IRequest<ResponseDto<NoContentDto>>
    {
        public Guid CityId { get; set; }
        public string DistrictName { get; set; }
    }
    public class AddDistrictRequestHandler(ILocationDbContext locationDbContext) : IRequestHandler<AddDistrictRequest, ResponseDto<NoContentDto>>
    {
        public async Task<ResponseDto<NoContentDto>> Handle(AddDistrictRequest request, CancellationToken cancellationToken)
        {
            var cityDbSet = locationDbContext.GetDbSet<Domain.Aggregates.City>();
            var getCity = await cityDbSet.FindAsync(request.CityId);

            if (getCity == null)
                return ResponseDto<NoContentDto>.Fail("invalid city");

            getCity.AddDistrict(request.DistrictName);

            await locationDbContext.SaveChangesAsync(cancellationToken);

            return ResponseDto<NoContentDto>.Success();
        }
    }
}
