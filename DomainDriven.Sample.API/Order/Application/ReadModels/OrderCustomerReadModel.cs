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
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string CurrentCityName { get; set; }
        public string CurrentDistrictName { get; set; }
        public string CurrentDetail { get; set; }

    }
    public class LocationReadModel
    {
        public string CityName { get; set; }
        public string DistrictName { get; set; }
        public string Detail { get; set; }
    }
}
