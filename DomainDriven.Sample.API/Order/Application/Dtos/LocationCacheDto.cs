namespace DomainDriven.Sample.API.Order.Application.Dtos
{
    public class LocationCacheDto
    {
        public List<CityDto> CityDto { get; set; }
    }
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
}
