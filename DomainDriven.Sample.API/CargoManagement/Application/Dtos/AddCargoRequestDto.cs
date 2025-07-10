namespace DomainDriven.Sample.API.CargoManagement.Application.Dtos
{
    public class AddCargoRequestDto
    {
        public int CustomerId { get; set; }
        public int OrderId { get; set; }
        public int CompanyId { get; set; }
        public int CityId { get; set; }
        public int DistrictId { get; set; }
        public string Detail { get; set; }
    }
}
