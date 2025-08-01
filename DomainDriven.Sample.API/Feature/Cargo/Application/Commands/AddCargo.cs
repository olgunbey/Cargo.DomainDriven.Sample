using DomainDriven.Sample.API.Common;
using DomainDriven.Sample.API.Feature.Cargo.Application.Interfaces;
using DomainDriven.Sample.API.Feature.Cargo.Domain.Aggregates;
using MediatR;

namespace DomainDriven.Sample.API.Feature.Cargo.Application.Commands
{
    public class AddCargoRequest : IRequest<ResponseDto<NoContentDto>>
    {
        public int CompanyId { get; set; }
        public Guid OrderId { get; set; }
        public DateTime EstimatedDateTime { get; set; }
        public List<ProductDto> Products { get; set; }

        public class ProductDto
        {
            public Guid Id { get; set; }
            public string Name { get; set; }
        }
    }
    public class AddCargoRequestHandler(ICargoDbContext cargoDbContext) : IRequestHandler<AddCargoRequest, ResponseDto<NoContentDto>>
    {
        public async Task<ResponseDto<NoContentDto>> Handle(AddCargoRequest request, CancellationToken cancellationToken)
        {
            var cargoInformation = new CargoInformation(request.CompanyId, request.EstimatedDateTime, request.OrderId);


            var productDto = request.Products.Select(y => (y.Id, y.Name));

            cargoInformation.AddProduct(productDto);

            cargoDbContext.GetDbSet<CargoInformation>()
                .Add(cargoInformation);

            await cargoDbContext.SaveChangesAsync(cancellationToken);

            return ResponseDto<NoContentDto>.Success();


        }
    }
}
