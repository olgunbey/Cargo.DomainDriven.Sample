using DomainDriven.Sample.API.Feature.Order.Application.Interfaces;
using DomainDriven.Sample.API.Feature.Order.Domain.Enums;

namespace DomainDriven.Sample.API
{
    public class OrderStatusAcceptedUpdatedJob(IOrderDbContext orderDbContext) : IJob
    {
        public async Task Execute()
        {
            var acceptedOrderInformations = orderDbContext.OrderInformation
                .Where(y => y.OrderStatus == OrderStatus.Accepted);

            foreach (var acceptedOrderInformation in acceptedOrderInformations)
            {
                acceptedOrderInformation.UpdateStatus(OrderStatus.Processing);
            }
            await orderDbContext.SaveChangesAsync();
        }
    }
}
