namespace DomainDriven.Sample.API.Employee.Application.Dtos
{
    public class LocationCacheDto
    {
        public class CityDto
        {
            public int CityId { get; set; }
            public string CityName { get; set; }
            public List<DistrictDto> Districts { get; set; }
        }
        public class DistrictDto
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }

        public List<CityDto> City { get; set; }
    }

}
