using DomainDriven.Sample.API.Location.Application.IRepositories;
using DomainDriven.Sample.API.Location.Domain.Aggregates;
using MediatR;

namespace DomainDriven.Sample.API.Location.Application.Commands
{
    public class AddCityRequest : IRequest<bool>
    {
        public string Name { get; set; }
    }
    public class AddCityHandler(ILocationDbContext applicationDbContext) : IRequestHandler<AddCityRequest, bool>
    {
        public async Task<bool> Handle(AddCityRequest request, CancellationToken cancellationToken)
        {
            var addedCity = new City().GenerateCity(request.Name);
            applicationDbContext.GetDbSet<City>().Add(addedCity);
            await applicationDbContext.SaveChangesAsync(cancellationToken);
            return true;
        }
    }
}
