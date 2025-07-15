namespace DomainDriven.Sample.API.Employee.Application.Dtos
{
    public class CacheOrderInformationDto
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public List<OrderItem> OrderItems { get; set; }
        public TargetLocation TargetLocation { get; set; }
    }
    public class OrderItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Count { get; set; }
        public decimal Weight { get; set; }

    }
    public class TargetLocation
    {
        public int CityId { get; set; }
        public int DistrictId { get; set; }
        public string Detail { get; set; }
    }
}
