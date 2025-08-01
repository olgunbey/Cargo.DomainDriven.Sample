using DomainDriven.Sample.API.Common;
using DomainDriven.Sample.API.Feature.Cargo.Application.Interfaces;
using DomainDriven.Sample.API.Feature.Cargo.Domain.Aggregates;
using MediatR;

namespace DomainDriven.Sample.API.Feature.Cargo.Application.Queries
{
    public class CargoStateGetByCargoCodeRequest : IRequest<ResponseDto<NoContentDto>>
    {
        public string CargoCode { get; set; }
    }
    public class CargoStateGetByCargoCodeRequestHandler(ICargoDbContext cargoDbContext) : IRequestHandler<CargoStateGetByCargoCodeRequest, ResponseDto<NoContentDto>>
    {
        public Task<ResponseDto<NoContentDto>> Handle(CargoStateGetByCargoCodeRequest request, CancellationToken cancellationToken)
        {
            var cargoDbSet = cargoDbContext.GetDbSet<CargoInformation>();
            var getCargoInformation = cargoDbSet.Single(y => y.CargoCode == request.CargoCode);

            cargoDbSet.Entry(getCargoInformation)
                .Collection(y => y.Products);


            throw new NotImplementedException();
        }
    }

}
