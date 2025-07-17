namespace DomainDriven.Sample.API.Employee.Application.Queries
{
    public class CustomerAndOrderEmployeeReadModel
    {
        public int EmployeeId { get; set; }
        public OrderReadModel OrderReadModel { get; set; }
    }
    public class CustomerReadModel
    {
        public string CustomerName { get; set; }
        public string CurrentLocationCityName { get; set; }
        public string CurrentLocationDistrictName { get; set; }
    }
    public class OrderItemReadModel
    {
        public string Name { get; set; }
        public int Count { get; set; }
        public double Weight { get; set; }
    }
    public class OrderReadModel
    {
        public string CityName { get; set; }
        public string DistrictName { get; set; }
        public CustomerReadModel CustomerReadModel { get; set; }
        public List<OrderItemReadModel> OrderItems { get; set; }
    }


}
