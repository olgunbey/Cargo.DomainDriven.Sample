namespace DomainDriven.Sample.API.Employee.Application.Dtos
{
    public class GetAllSelectedEmloyeeResponseDto
    {
        public List<OrderDto> OrderDto { get; set; }
    }
    public class OrderDto
    {
        public CustomerDto CustomerDto { get; set; }
        public List<OrderItemDto> OrderItems { get; set; }
        public LocationDto TargetLocation { get; set; }
    }

    public class CustomerDto
    {
        public int Id { get; set; }
        public LocationDto CurrentLocation { get; set; }
    }
    public class OrderItemDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Count { get; set; }
        public decimal Weight { get; set; }
    }
    public class LocationDto
    {
        public int CityId { get; set; }
        public int DistrictId { get; set; }
        public string Detail { get; set; }
    }


}
