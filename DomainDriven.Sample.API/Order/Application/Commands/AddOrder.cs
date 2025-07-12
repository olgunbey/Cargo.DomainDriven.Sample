using DomainDriven.Sample.API.Common;
using DomainDriven.Sample.API.Order.Application.Dtos;
using DomainDriven.Sample.API.Order.Application.IRepositories;
using DomainDriven.Sample.API.Order.Domain.Exceptions;
using DomainDriven.Sample.API.Order.Domain.Repository;
using MediatR;

namespace DomainDriven.Sample.API.Order.Application.Commands
{
    public class AddOrderRequest : IRequest<ResponseDto<NoContentDto>>
    {
        public AddOrderRequestDto RequestDto { get; set; }
    }
    public class AddOrderRequestHandler(IOrder order, IOrderDbContext orderDbContext) : IRequestHandler<AddOrderRequest, ResponseDto<NoContentDto>>
    {
        public async Task<ResponseDto<NoContentDto>> Handle(AddOrderRequest request, CancellationToken cancellationToken)
        {
            Domain.Aggregates.Order generateOrder = order.GenerateOrder(request.RequestDto.CustomerId, request.RequestDto.CityId, request.RequestDto.DistrictId, request.RequestDto.Detail);
            try
            {
                request.RequestDto.OrderItems.ForEach(item =>
                {
                    generateOrder.AddOrderItem(item.Name, item.Weight, item.Count);
                });
            }
            catch (InvalidWeightException ex)
            {
                return ResponseDto<NoContentDto>.Fail(ex.Message, 400);
            }
            orderDbContext.GetDbSet<Domain.Aggregates.Order>().Add(generateOrder);
            await orderDbContext.SaveChangesAsync(cancellationToken);
            return ResponseDto<NoContentDto>.Success(201);

        }
    }
}
