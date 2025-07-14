namespace DomainDriven.Sample.API.Location.Application.Dtos
{
    public class GetAllCityAndDistrictResponseDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<DistrictDto> District { get; set; }
    }
    public class DistrictDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
