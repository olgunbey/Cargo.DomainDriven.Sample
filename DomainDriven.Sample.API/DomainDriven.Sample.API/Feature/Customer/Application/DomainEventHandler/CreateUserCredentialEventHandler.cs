using DomainDriven.Sample.API.Feature.Customer.Domain.Aggregates;
using DomainDriven.Sample.API.Feature.Customer.Domain.Events;
using DomainDriven.Sample.API.Feature.Customer.Infrastructure.Persistence;
using MediatR;

namespace DomainDriven.Sample.API.Feature.Customer.Application.DomainEventHandler
{
    public class CreateUserCredentialEventHandler(ICustomerDbContext customerDbContext) : INotificationHandler<CreateUserCredentialEvent>
    {
        public async Task Handle(CreateUserCredentialEvent notification, CancellationToken cancellationToken)
        {
            var userInformation = new UserInformation(notification.Name, notification.Surname, notification.Gender, notification.UserId);
            await customerDbContext.UserInformation.AddAsync(userInformation);
        }
    }
}
