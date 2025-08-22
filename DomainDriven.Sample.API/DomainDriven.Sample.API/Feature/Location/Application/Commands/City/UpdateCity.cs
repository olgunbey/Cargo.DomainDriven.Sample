using DomainDriven.Sample.API.Common;
using DomainDriven.Sample.API.Feature.Location.Application.Interfaces;
using MediatR;

namespace DomainDriven.Sample.API.Feature.Location.Application.Commands.City
{
    public class UpdateCityRequest : IRequest<Result<NoContentDto>>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
    public class UpdateCityRequestHandler(ILocationDbContext locationDbContext) : IRequestHandler<UpdateCityRequest, Result<NoContentDto>>
    {
        public async Task<Result<NoContentDto>> Handle(UpdateCityRequest request, CancellationToken cancellationToken)
        {
            var getCityById = await locationDbContext.City.FindAsync(request.Id);

            getCityById.UpdateCity(request.Id, request.Name);

            await locationDbContext.SaveChangesAsync(cancellationToken);

            return Result<NoContentDto>.Success();
        }
    }
}
