namespace DomainDriven.Sample.API.Order.Application.Dtos
{
    public class AddOrderRequestDto
    {
        public int CustomerId { get; set; }
        public List<AddOrderItemRequestDto> OrderItems { get; set; }
        public int CityId { get; set; }
        public int DistrictId { get; set; }
        public string Detail { get; set; }
        public int EmployeeId { get; set; }
    }
    public class AddOrderItemRequestDto
    {
        public string Name { get; set; }
        public decimal Weight { get; set; }
        public int Count { get; set; }
    }
}
