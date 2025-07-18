using DomainDriven.Sample.API.Order.Application.Dtos;
using DomainDriven.Sample.API.Order.Application.IRepositories;

namespace DomainDriven.Sample.API.Order.ACL
{
    public class CustomerApiClient(HttpClient httpClient) : ICustomerApiClient
    {
        public async Task<CustomerApiResponse> GetCustomerById(int customerId)
        {
            return await httpClient.GetFromJsonAsync<CustomerApiResponse>($"api/customer/getCustomerById?customerId={customerId}");
        }
    }
}
