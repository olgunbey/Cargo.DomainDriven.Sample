namespace DomainDriven.Sample.API.Feature.Customer.Domain.ReadModels
{
    public class CustomerReadModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public bool Gender { get; set; }
    }
}
