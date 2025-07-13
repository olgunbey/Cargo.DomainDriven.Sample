namespace DomainDriven.Sample.API.Location.Application.Dtos
{
    public class GetAllCityAndDistrictResponseDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<District> District { get; set; }
    }
    public class District
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
