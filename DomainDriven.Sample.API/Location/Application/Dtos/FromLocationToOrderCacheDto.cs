namespace DomainDriven.Sample.API.Location.Application.Dtos
{
    public class FromLocationToOrderCacheDto
    {
        public int CityId { get; set; }
        public string CityName { get; set; }
        public List<DistrictDto> Districts { get; set; }
    }
}
