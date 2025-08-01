namespace DomainDriven.Sample.API.Feature.Order.Domain.ReadModel
{
    public class OrderProductRealModel
    {
        public Guid OrderId { get; set; }
        public Guid ProductId { get; set; }
        public string ProductName { get; set; }
    }
}
