using DomainDriven.Sample.API.Common;
using DomainDriven.Sample.API.Feature.Location.Application.Interfaces;
using MediatR;

namespace DomainDriven.Sample.API.Feature.Location.Application.Commands.City
{
    public class UpdateCityRequest : IRequest<ResponseDto<NoContentDto>>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
    public class UpdateCityRequestHandler(ILocationDbContext locationDbContext) : IRequestHandler<UpdateCityRequest, ResponseDto<NoContentDto>>
    {
        public async Task<ResponseDto<NoContentDto>> Handle(UpdateCityRequest request, CancellationToken cancellationToken)
        {
            var getCityById = await locationDbContext.GetDbSet<Domain.Aggregates.City>
                 ().FindAsync(request.Id);

            getCityById.UpdateCity(request.Id, request.Name);

            await locationDbContext.SaveChangesAsync(cancellationToken);

            return ResponseDto<NoContentDto>.Success();
        }
    }
}
