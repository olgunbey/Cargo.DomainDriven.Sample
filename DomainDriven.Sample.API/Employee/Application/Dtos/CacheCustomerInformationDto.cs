namespace DomainDriven.Sample.API.Employee.Application.Dtos
{
    public class CacheCustomerInformationDto
    {
        public class CurrentLocation
        {
            public int CityId { get; set; }
            public int DistrictId { get; set; }
            public string Detail { get; set; }
        }
        public int Id { get; set; }
        public CurrentLocation Location { get; set; }
    }

}
