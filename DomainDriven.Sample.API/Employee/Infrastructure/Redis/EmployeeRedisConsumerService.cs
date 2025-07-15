using DomainDriven.Sample.API.Employee.Application.Dtos;
using DomainDriven.Sample.API.Employee.Application.IRepositories.Redis;
using ServiceStack.Redis;

namespace DomainDriven.Sample.API.Employee.Infrastructure.Redis
{
    public class EmployeeRedisConsumerService(IRedisClientsManagerAsync redisClientsManager) : IEmployeeRedisConsumer
    {
        public async Task<IEnumerable<CacheCustomerInformationDto>> GetCustomerInformationByIdAsync(List<int> customerIds)
        {
            await using (var client = await redisClientsManager.GetClientAsync())
            {
                var cacheData = await client.GetAsync<List<CacheCustomerInformationDto>>("from_customer_to_selectedEmployee");

                return cacheData.IntersectBy(customerIds, x => x.Id);

            }
        }

        public async Task<IEnumerable<CacheOrderInformationDto>> GetOrderInformationByIdAsync(List<int> orderIds)
        {
            await using (var client = await redisClientsManager.GetClientAsync())
            {
                var cacheData = await client.GetAsync<List<CacheOrderInformationDto>>("from_order_to_selectedEmployee");

                return cacheData.IntersectBy(orderIds, x => x.Id);
            }
        }
    }
}
