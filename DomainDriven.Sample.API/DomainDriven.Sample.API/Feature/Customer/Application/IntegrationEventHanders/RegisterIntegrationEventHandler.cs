using DomainDriven.Sample.API.Feature.Customer.Infrastructure.Persistence;
using DomainDriven.Sample.API.IntegrationEvents;
using MassTransit;

namespace DomainDriven.Sample.API.Feature.Customer.Application.IntegrationEventHanders
{
    public class RegisterIntegrationEventHandler(ICustomerDbContext customerDbContext) : IConsumer<RegisterIntegrationEvent>
    {
        public async Task Consume(ConsumeContext<RegisterIntegrationEvent> context)
        {
            customerDbContext.CustomerReadModel.Add(new Domain.ReadModels.CustomerReadModel()
            {
                Id = context.Message.UserId,
                Name = context.Message.Name,
                Surname = context.Message.Surname,
                Gender = context.Message.Gender
            });

            await customerDbContext.SaveChangesAsync();
        }
    }
}
