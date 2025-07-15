using DomainDriven.Sample.API.Employee.Application.Dtos;

namespace DomainDriven.Sample.API.Employee.Application.IRepositories.Redis
{
    public interface IEmployeeRedisConsumer
    {
        public Task<IEnumerable<CacheOrderInformationDto>> GetOrderInformationByIdAsync(List<int> orderIds);

        public Task<IEnumerable<CacheCustomerInformationDto>> GetCustomerInformationByIdAsync(List<int> customerIds);
    }
}
