namespace DomainDriven.Sample.API.Feature.Order.Domain.ReadModel
{
    public class OrderProductReadModel
    {
        public Guid OrderId { get; set; }
        public Guid ProductId { get; set; }
        public string ProductName { get; set; }
        public int Count { get; set; }
        public Guid CustomerOrderTargetLocationId { get; set; }
        public string Detail { get; set; }
    }
}
