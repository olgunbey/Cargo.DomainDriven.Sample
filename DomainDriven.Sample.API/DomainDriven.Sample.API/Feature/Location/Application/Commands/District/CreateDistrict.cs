using DomainDriven.Sample.API.Common;
using DomainDriven.Sample.API.Feature.Location.Application.Interfaces;
using MediatR;

namespace DomainDriven.Sample.API.Feature.Location.Application.Commands.District
{
    public class CreateDistrictRequest : IRequest<Result<NoContentDto>>
    {
        public Guid CityId { get; set; }
        public string DistrictName { get; set; }
    }
    public class CreateDistrictRequestHandler(ILocationDbContext locationDbContext) : IRequestHandler<CreateDistrictRequest, Result<NoContentDto>>
    {
        public async Task<Result<NoContentDto>> Handle(CreateDistrictRequest request, CancellationToken cancellationToken)
        {
            var getCity = await locationDbContext.City.FindAsync(request.CityId);

            if (getCity == null)
                return Result<NoContentDto>.Fail("invalid city");

            getCity.AddDistrict(request.DistrictName);

            await locationDbContext.SaveChangesAsync(cancellationToken);

            return Result<NoContentDto>.Success();
        }
    }
}
