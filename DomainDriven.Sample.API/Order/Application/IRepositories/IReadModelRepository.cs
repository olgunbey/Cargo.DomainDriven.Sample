namespace DomainDriven.Sample.API.Order.Application.IRepositories
{
    public interface IReadModelRepository<T> where T : class
    {
        public List<T> GetAllReadModel(); 
    }
}
