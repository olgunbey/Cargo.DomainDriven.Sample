using DomainDriven.Sample.API.Order.Application.Dtos;

namespace DomainDriven.Sample.API.Order.Application.IRepositories
{
    public interface ICustomerApiClient
    {
        public Task<CustomerApiResponse> GetCustomerById(int customerId);
    }
}
