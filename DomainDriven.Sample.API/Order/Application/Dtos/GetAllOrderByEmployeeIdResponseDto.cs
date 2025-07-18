namespace DomainDriven.Sample.API.Order.Application.Dtos
{
    public class GetAllOrderByEmployeeIdResponseDto
    {
        public class LocationResponseDto
        {
            public string CityName { get; set; }
            public string DistrictName { get; set; }
            public string Detail { get; set; }
        }
        public class CustomerResponseDto
        {
            public int Id { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string PhoneNumber { get; set; }
            public LocationResponseDto Location { get; set; }
        }
        public class OrderResponseDto
        {
            public CustomerResponseDto CustomerResponseDto { get; set; }
            public LocationResponseDto TargetLocation { get; set; }
            public List<OrderItemDto> OrderItems { get; set; }
        }
        public class OrderItemDto
        {
            public string Name { get;  set; }
            public int Count { get;  set; }
            public decimal Weight { get;  set; }
        }
        public int Id { get; set; }
        public OrderResponseDto Order { get; set; }

    }
}
