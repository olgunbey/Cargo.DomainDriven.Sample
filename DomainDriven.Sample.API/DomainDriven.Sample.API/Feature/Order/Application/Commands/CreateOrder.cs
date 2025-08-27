    using DomainDriven.Sample.API.Common;
using DomainDriven.Sample.API.Feature.Order.Application.Interfaces;
using DomainDriven.Sample.API.Feature.Order.Domain.Aggregates;
using MediatR;

namespace DomainDriven.Sample.API.Feature.Order.Application.Commands
{
    public class CreateOrderRequest : IRequest<Result<NoContentDto>>
    {
        public Guid CityId { get; set; }
        public string CityName { get; set; }
        public Guid DistrictId { get; set; }
        public string DistrictName { get; set; }
        public string Detail { get; set; }
        public Guid CustomerId { get; set; }
        public List<ProductItem> ProductItems { get; set; }
        public Guid LocationId { get; set; }
        public class ProductItem
        {
            public Guid Id { get; set; }
            public string Name { get; set; }
            public int Quantity { get; set; }
            public int Price { get; set; }
        }

    }
    public class CreateOrderRequestHandler(IOrderDbContext orderDbContext) : IRequestHandler<CreateOrderRequest, Result<NoContentDto>>
    {
        public async Task<Result<NoContentDto>> Handle(CreateOrderRequest request, CancellationToken cancellationToken)
        {
            var productItems = request.ProductItems.Select(y => (id: y.Id, quantity: y.Quantity, name: y.Name,price:y.Price)).ToList();
            var generateOrder = new OrderInformation(request.CustomerId, request.LocationId);
            generateOrder.CreateOrder(request.DistrictId, request.DistrictName, request.CityId, request.CityName, request.Detail, productItems);
            orderDbContext.OrderInformation.Add(generateOrder);
            await orderDbContext.SaveChangesAsync(cancellationToken);

            return Result<NoContentDto>.Success();
        }
    }
}
