namespace DomainDriven.Sample.API.Feature.Location.Application.Dtos
{
    public class LocationCacheDto
    {
        public int Id { get; set; }
        public string CityName { get; set; }
        public List<DistrictDto> DistrictDtos { get; set; }
    }
    public class DistrictDto
    {
        public int Id { get; set; }
        public string DistrictName { get; set; }
    }
}
