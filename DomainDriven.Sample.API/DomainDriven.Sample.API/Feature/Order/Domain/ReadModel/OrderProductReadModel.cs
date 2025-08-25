namespace DomainDriven.Sample.API.Feature.Order.Domain.ReadModel
{
    public class OrderProductReadModel
    {
        public Guid Id { get; set; }
        public Guid CustomerId { get; set; }
        public Guid OrderId { get; set; }
        public Guid ProductId { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }
        public Guid CustomerOrderTargetLocationId { get; set; }
        public Guid DistrictId { get; set; }
        public string DistrictName { get; set; }
        public Guid CityId { get; set; }
        public string CityName { get; set; }
        public string Detail { get; set; }
    }
}
