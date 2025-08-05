using DomainDriven.Sample.API.Common;
using DomainDriven.Sample.API.Feature.Product.Application.Dtos;
using DomainDriven.Sample.API.Feature.Product.Application.Interfaces;
using MediatR;

namespace DomainDriven.Sample.API.Feature.Product.Application.Commands.Product
{
    public class UpdateProductRequest : IRequest<ResponseDto<UpdateProductDto>>
    {
        public Guid ProductId { get; set; }
        public string ProductName { get; set; }
        public int Stock { get; set; }
        public decimal Price { get; set; }
    }
    public class UpdateProductRequestHandler(IProductDbContext productDbContext) : IRequestHandler<UpdateProductRequest, ResponseDto<UpdateProductDto>>
    {
        public async Task<ResponseDto<UpdateProductDto>> Handle(UpdateProductRequest request, CancellationToken cancellationToken)
        {
            var product = await productDbContext.Product.FindAsync(request.ProductId);

            product.UpdateProduct(request.ProductName, request.Stock, request.Price);

            await productDbContext.SaveChangesAsync(cancellationToken);

            return ResponseDto<UpdateProductDto>.Success(new UpdateProductDto(product.Id, product.Name, product.Stock, product.Price));
        }
    }
}
