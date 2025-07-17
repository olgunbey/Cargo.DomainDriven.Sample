namespace DomainDriven.Sample.API.Order.Application.Dtos
{
    public class GetAllOrderByEmployeeIdResponseDto
    {
        public class LocationResponseDto
        {
            public int CityId { get; set; }
            public string CityName { get; set; }
            public int DistrictId { get; set; }
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
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int EmployeeId { get; set; }
        public CustomerResponseDto Customer { get; set; }
    }
}
