using DomainDriven.Sample.API.Common;
using DomainDriven.Sample.API.Feature.Cargo.Application.Dtos;
using DomainDriven.Sample.API.Feature.Cargo.Application.Interfaces;
using DomainDriven.Sample.API.Feature.Cargo.Domain.Aggregates;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DomainDriven.Sample.API.Feature.Cargo.Application.Queries
{
    public class CargoGetByCargoCodeRequest : IRequest<Result<CargoGetByCargoCodeResponseDto>>
    {
        public string CargoCode { get; set; }
    }
    public class CargoGetByCargoCodeRequestHandler() : IRequestHandler<CargoGetByCargoCodeRequest, Result<CargoGetByCargoCodeResponseDto>>
    {
        public async Task<Result<CargoGetByCargoCodeResponseDto>> Handle(CargoGetByCargoCodeRequest request, CancellationToken cancellationToken)
        {
            //var getCargoInformation = await cargoDbContext.CargoInformation.SingleAsync(y => y.CargoCode == request.CargoCode);

            //var productInfoGetByCargo = cargoDbContext.CargoProductReadModel.Where(y => y.CargoId == getCargoInformation.Id).ToList();

            //var responseData = new CargoGetByCargoCodeResponseDto()
            //{
            //    CargoId = getCargoInformation.Id,
            //    CargoCode = request.CargoCode,
            //    OrderDetailResponse = productInfoGetByCargo.Select(productInfo => new OrderDetailResponseDto()
            //    {
            //        CityName = productInfo.CityName,
            //        Detail = productInfo.Detail,
            //        DistrictName = productInfo.DistrictName,
            //        ProductId = productInfo.ProductId,
            //        ProductName = productInfo.ProductName,
            //    }).ToList()
            //};

            return Result<CargoGetByCargoCodeResponseDto>.Success(new CargoGetByCargoCodeResponseDto());
        }
    }

}
