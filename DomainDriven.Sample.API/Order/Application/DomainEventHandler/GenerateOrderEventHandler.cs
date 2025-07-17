using DomainDriven.Sample.API.Order.Domain.Events;
using MediatR;

namespace DomainDriven.Sample.API.Order.Application.DomainEventHandler
{
    public class GenerateOrderEventHandler : INotificationHandler<GenerateOrderEvent>
    {
        public Task Handle(GenerateOrderEvent notification, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
