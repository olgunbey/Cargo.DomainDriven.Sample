using DomainDriven.Sample.API.IntegrationEvents.Employee;
using DomainDriven.Sample.API.Order.Application.IRepositories;
using MassTransit;
using Microsoft.EntityFrameworkCore;

namespace DomainDriven.Sample.API.Order.Domain.IntegrationEventHandler
{
    public class EmployeeCargoApprovedIntegrationEventHandler(IOrderDbContext orderDbContext) : IConsumer<EmployeeCargoApprovedIntegrationEvent>
    {
        public async Task Consume(ConsumeContext<EmployeeCargoApprovedIntegrationEvent> context)
        {
            DbSet<Order.Domain.Aggregates.Order> orderDb
                = orderDbContext.GetDbSet<Domain.Aggregates.Order>();

            var getOrder = await orderDb.FindAsync(context.Message.OrderId);

            if (getOrder == null)
            {
                return;
            }
            getOrder.SetApproved(context.Message.Approved);

            await orderDbContext.SaveChangesAsync(context.CancellationToken);
        }
    }
}
