using DomainDriven.Sample.API.Common;
using DomainDriven.Sample.API.Feature.Order.Application.Interfaces;
using DomainDriven.Sample.API.Feature.Order.Domain.Aggregates;
using DomainDriven.Sample.API.Feature.Order.Domain.Interfaces;
using MediatR;

namespace DomainDriven.Sample.API.Feature.Order.Application.Commands
{
    public class CreateOrderRequest : IRequest<ResponseDto<NoContentDto>>
    {
        public int DistrictId { get; set; }
        public int CityId { get; set; }
        public string Detail { get; set; }
        public int CustomerId { get; set; }
        public List<int> ProductItemIds { get; set; }
        public bool PaymentStatus { get; set; }
    }
    public class CreateOrderRequestHandler(IOrderDbContext orderDbContext, IOrderInformation orderInformation) : IRequestHandler<CreateOrderRequest, ResponseDto<NoContentDto>>
    {
        public async Task<ResponseDto<NoContentDto>> Handle(CreateOrderRequest request, CancellationToken cancellationToken)
        {
            var generateOrder = orderInformation.CreateOrder(request.DistrictId, request.CityId, request.Detail, request.CustomerId, request.ProductItemIds, request.PaymentStatus);

            orderDbContext.GetDbSet<OrderInformation>()
                .Add(generateOrder);

            await orderDbContext.SaveChangesAsync(cancellationToken);

            return ResponseDto<NoContentDto>.Success();
        }
    }
}
