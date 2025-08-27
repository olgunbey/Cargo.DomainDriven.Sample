using DomainDriven.Sample.API.Common;
using DomainDriven.Sample.API.Feature.Order.Application.Interfaces;
using DomainDriven.Sample.API.Feature.Order.Domain.Enums;
using MediatR;

namespace DomainDriven.Sample.API.Feature.Order.Application.Queries
{
    public class GetAllOrderByCustomerIdRequest : IRequest<Result<List<ResponseDto>>>
    {
        public Guid CustomerId { get; set; }
    }
    public class GetAllOrderByCustomerIdRequestHandler(IOrderDbContext orderDbContext) : IRequestHandler<GetAllOrderByCustomerIdRequest, Result<List<ResponseDto>>>
    {
        public async Task<Result<List<ResponseDto>>> Handle(GetAllOrderByCustomerIdRequest request, CancellationToken cancellationToken)
        {
            var data = orderDbContext.OrderProductReadModel
                 .Where(x => x.CustomerId == request.CustomerId)
                 .GroupBy(y => new { y.OrderId, y.CityName, y.Detail, y.DistrictName, y.OrderStatus })
                 .Select(g => new ResponseDto()
                 {
                     OrderId = g.Key.OrderId,
                     DistrictName = g.Key.DistrictName,
                     OrderStatus = g.Key.OrderStatus,
                     CityName = g.Key.CityName,
                     Detail = g.Key.Detail,
                     ProductItems = g.Select(x => new ResponseDto.ProductItem()
                     {
                         Id = x.ProductId,
                         Name = x.ProductName,
                         Quantity = x.Quantity,
                         Price = x.Price
                     }).ToList()
                 }).ToList();

            return Result<List<ResponseDto>>.Success(data);

        }
    }
    public class ResponseDto
    {
        public Guid OrderId { get; set; }
        public string CityName { get; set; }
        public string DistrictName { get; set; }
        public string Detail { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public List<ProductItem> ProductItems { get; set; }

        public class ProductItem
        {
            public Guid Id { get; set; }
            public string Name { get; set; }
            public int Quantity { get; set; }
            public int Price { get; set; }
        }

    }

}
