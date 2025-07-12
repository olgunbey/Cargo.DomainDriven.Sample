using DomainDriven.Sample.API.Location.Application.IRepositories;
using DomainDriven.Sample.API.Location.Domain.Aggregates;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DomainDriven.Sample.API.Location.Application.Commands
{
    public class AddDistrictRequest : IRequest<bool>
    {
        public int CityId { get; set; }
        public string Name { get; set; }
    }
    public class AddDistrictHandler(ILocationDbContext applicationDbContext) : IRequestHandler<AddDistrictRequest, bool>
    {
        public async Task<bool> Handle(AddDistrictRequest request, CancellationToken cancellationToken)
        {
            DbSet<City> dbCity = applicationDbContext.GetDbSet<City>();
            City? city = await dbCity.FirstOrDefaultAsync(y => y.Id == request.CityId);

            if (city == null)
                return false;

            city.AddDistrict(request.Name);

            await applicationDbContext.SaveChangesAsync(cancellationToken);
            return true;

        }
    }
}
