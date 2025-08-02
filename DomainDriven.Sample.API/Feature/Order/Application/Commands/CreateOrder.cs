using DomainDriven.Sample.API.Common;
using DomainDriven.Sample.API.Feature.Order.Application.Interfaces;
using DomainDriven.Sample.API.Feature.Order.Domain.Aggregates;
using MediatR;

namespace DomainDriven.Sample.API.Feature.Order.Application.Commands
{
    public class CreateOrderRequest : IRequest<ResponseDto<NoContentDto>>
    {
        public Guid CityId { get; set; }
        public Guid DistrictId { get; set; }
        public string Detail { get; set; }
        public int CustomerId { get; set; }
        public List<ProductItem> ProductItems { get; set; }
        public bool PaymentStatus { get; set; }
        public class ProductItem
        {
            public Guid Id { get; set; }
            public string Name { get; set; }
            public int Count { get; set; }
        }

    }
    public class CreateOrderRequestHandler(IOrderDbContext orderDbContext) : IRequestHandler<CreateOrderRequest, ResponseDto<NoContentDto>>
    {
        public async Task<ResponseDto<NoContentDto>> Handle(CreateOrderRequest request, CancellationToken cancellationToken)
        {

            List<(Guid ProductId, string ProductName, int Count)> productItems = request.ProductItems.Select(y => (ProductId: y.Id, ProductName: y.Name, Count: y.Count)).ToList();
            var generateOrder = new OrderInformation(request.CityId, request.DistrictId, request.Detail, request.CustomerId, productItems, request.PaymentStatus);

            orderDbContext.OrderInformation.Add(generateOrder);

            await orderDbContext.SaveChangesAsync(cancellationToken);

            return ResponseDto<NoContentDto>.Success();
        }
    }
}
