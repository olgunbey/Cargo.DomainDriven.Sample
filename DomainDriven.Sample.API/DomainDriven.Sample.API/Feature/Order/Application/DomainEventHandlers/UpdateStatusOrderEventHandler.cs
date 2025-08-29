
using DomainDriven.Sample.API.Feature.Order.Application.Dtos;
using DomainDriven.Sample.API.Feature.Order.Application.Interfaces;
using DomainDriven.Sample.API.IntegrationEvents;
using MassTransit;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DomainDriven.Sample.API.Feature.Order.Application.DomainEventHandlers
{
    public class UpdateStatusOrderEventHandler(IPublishEndpoint publishEndpoint, IOrderDbContext orderDbContext) : INotificationHandler<Domain.Events.UpdateStatusOrderEvent>
    {
        public async Task Handle(Domain.Events.UpdateStatusOrderEvent notification, CancellationToken cancellationToken)
        {
            EventOrderStatus orderStatus = OrderStatusMapper.MapToEventStatus(notification.OrderStatus);
            var orderInfo = await orderDbContext.OrderProductReadModel.Where(y => y.OrderId == notification.OrderId).FirstAsync();

            await orderDbContext.OrderProductReadModel
                .Where(y=>y.OrderId==notification.OrderId)
                .ExecuteUpdateAsync(y => y.SetProperty(rm => rm.OrderStatus, val => notification.OrderStatus));

            var @event = new UpdateStatusOrderToCargoEvent(
                notification.OrderId,
                orderStatus,
                orderInfo.CityId,
                orderInfo.CityName,
                orderInfo.DistrictId,
                orderInfo.DistrictName,
                orderInfo.Detail);

            await publishEndpoint.Publish(@event);
        }
    }
}
