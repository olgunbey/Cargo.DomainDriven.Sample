using DomainDriven.Sample.API.Database;
using DomainDriven.Sample.API.Location.Domain.Aggregates;
using MediatR;

namespace DomainDriven.Sample.API.Location.Application.Commands
{
    public class AddCityRequest : IRequest<bool>
    {
        public string Name { get; set; }
    }
    public class AddCityHandler(IApplicationDbContext applicationDbContext) : IRequestHandler<AddCityRequest, bool>
    {
        public async Task<bool> Handle(AddCityRequest request, CancellationToken cancellationToken)
        {
            var addedCity = new City().GenerateCity(request.Name);
            applicationDbContext.GetEntity<City>().Add(addedCity);
            await applicationDbContext.SaveChangesAsync(cancellationToken);
            return true;
        }
    }
}
