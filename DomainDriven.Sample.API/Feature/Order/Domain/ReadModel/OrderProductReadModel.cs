namespace DomainDriven.Sample.API.Feature.Order.Domain.ReadModel
{
    public class OrderProductReadModel
    {
        public Guid OrderId { get; set; }
        public Guid ProductId { get; set; }
        public string ProductName { get; set; }
        public int Count { get; set; }
        public Guid CityId { get; set; }
        public string CityName { get; set; }
        public Guid DistrictId { get; set; }
        public string DistrictName { get; set; }
        public string Detail { get; set; }
    }
}
