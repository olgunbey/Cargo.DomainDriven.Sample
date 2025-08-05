using Microsoft.EntityFrameworkCore;

namespace DomainDriven.Sample.API.Common
{
    public interface IBaseDbContext
    {
        public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
