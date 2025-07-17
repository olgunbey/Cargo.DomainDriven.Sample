namespace DomainDriven.Sample.API.Location.Application.Dtos
{
    public class LocationCacheDto
    {
        public List<CityDto> CityDtos { get; set; }
    }
    public class CityDto
    {
        public int CityId { get; set; }
        public string CityName { get; set; }
        public List<DistrictDto> Districts { get; set; }
    }

}
