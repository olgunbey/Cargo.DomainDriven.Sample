using DomainDriven.Sample.API.Database;
using DomainDriven.Sample.API.Location.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DomainDriven.Sample.API.Location.Application.Commands
{
    public class AddNeighbourhoodRequest : IRequest<bool>
    {
        public int DistrictId { get; set; }
        public string Name { get; set; }
    }
    public class AddNeighbourRequestHandler(IApplicationDbContext applicationDbContext) : IRequestHandler<AddNeighbourhoodRequest, bool>
    {
        public async Task<bool> Handle(AddNeighbourhoodRequest request, CancellationToken cancellationToken)
        {
            DbSet<District> dbDistrict = applicationDbContext.GetEntity<District>();

            District? district = await dbDistrict.FirstOrDefaultAsync(y => y.Id == request.DistrictId);

            if (district == null)
                return false;

            district.AddNeighbourhood(request.Name);
            await applicationDbContext.SaveChangesAsync(cancellationToken);
            return true;
        }
    }
}
