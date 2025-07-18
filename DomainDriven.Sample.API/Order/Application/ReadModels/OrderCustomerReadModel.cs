namespace DomainDriven.Sample.API.Order.Application.ReadModels
{
    public class OrderCustomerReadModel
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int EmployeeId { get; set; }
        public CustomerReadModelDto CustomerReadModel { get; set; }
        public LocationReadModel TargetLocationModel { get; set; }
    }
    public class CustomerReadModelDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public LocationReadModel CurrentLocationModel { get; set; }
    }
    public class LocationReadModel
    {
        public int CityId { get; set; }
        public string CityName { get; set; }
        public int DistrictId { get; set; }
        public string DistrictName { get; set; }
        public string Detail { get; set; }
    }
}
