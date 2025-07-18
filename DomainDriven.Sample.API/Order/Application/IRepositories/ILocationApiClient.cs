using DomainDriven.Sample.API.Order.Application.Dtos;

namespace DomainDriven.Sample.API.Order.Application.IRepositories
{
    public interface ILocationApiClient
    {
        public Task<LocationApiResponse> GetLocationById(int cityId, int districtId);
    }
}
