using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace DomainDriven.Sample.API.Database
{
    public class DesignTimeFactory : IDesignTimeDbContextFactory<CargoDbContext>
    {
        public CargoDbContext CreateDbContext(string[] args)
        {
            DbContextOptionsBuilder<CargoDbContext> optionsBuilder =new DbContextOptionsBuilder<CargoDbContext>();
            optionsBuilder.UseNpgsql(Configuration.ConnectionString);
            return new CargoDbContext(optionsBuilder.Options, new Mediatr());
        }
        private class Mediatr : IMediator
        {
            public IAsyncEnumerable<TResponse> CreateStream<TResponse>(IStreamRequest<TResponse> request, CancellationToken cancellationToken = default)
            {
                throw new NotImplementedException();
            }

            public IAsyncEnumerable<object?> CreateStream(object request, CancellationToken cancellationToken = default)
            {
                throw new NotImplementedException();
            }

            public Task Publish(object notification, CancellationToken cancellationToken = default)
            {
                throw new NotImplementedException();
            }

            public Task Publish<TNotification>(TNotification notification, CancellationToken cancellationToken = default) where TNotification : INotification
            {
                throw new NotImplementedException();
            }

            public Task<TResponse> Send<TResponse>(IRequest<TResponse> request, CancellationToken cancellationToken = default)
            {
                throw new NotImplementedException();
            }

            public Task Send<TRequest>(TRequest request, CancellationToken cancellationToken = default) where TRequest : IRequest
            {
                throw new NotImplementedException();
            }

            public Task<object?> Send(object request, CancellationToken cancellationToken = default)
            {
                throw new NotImplementedException();
            }
        }
    }
}
