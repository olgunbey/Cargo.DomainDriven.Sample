using DomainDriven.Sample.API.CargoManagement.Domain.Aggregates;

namespace DomainDriven.Sample.API.CargoManagement.Application.IRepositories
{
    public interface ICargoInformationRepository
    {
        public Task<CargoInformation> AddCargoInformation(CargoInformation cargoInformation);
    }
}
