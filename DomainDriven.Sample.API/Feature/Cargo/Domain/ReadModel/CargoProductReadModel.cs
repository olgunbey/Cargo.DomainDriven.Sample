namespace DomainDriven.Sample.API.Feature.Cargo.Domain.ReadModel
{
    public class CargoProductReadModel
    {
        public Guid Id { get; set; }
        public Guid CargoId { get; set; }
        public Guid ProductId { get; set; }
        public string ProductName { get; set; }
    }
}
