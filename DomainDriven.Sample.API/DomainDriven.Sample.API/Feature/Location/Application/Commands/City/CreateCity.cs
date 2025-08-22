using DomainDriven.Sample.API.Common;
using DomainDriven.Sample.API.Feature.Location.Application.Interfaces;
using MediatR;

namespace DomainDriven.Sample.API.Feature.Location.Application.Commands.City
{
    public class CreateCityRequest : IRequest<Result<NoContentDto>>
    {
        public string CityName { get; set; }
    }
    public class CreateRequestHandler(ILocationDbContext locationDbContext) : IRequestHandler<CreateCityRequest, Result<NoContentDto>>
    {
        public async Task<Result<NoContentDto>> Handle(CreateCityRequest request, CancellationToken cancellationToken)
        {
            var generateCity= new Domain.Aggregates.City(request.CityName);
            await locationDbContext.City.AddAsync(generateCity);
            await locationDbContext.SaveChangesAsync(cancellationToken);

            return Result<NoContentDto>.Success();
        }
    }
}
