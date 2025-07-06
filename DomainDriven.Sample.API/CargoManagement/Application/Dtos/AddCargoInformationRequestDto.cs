namespace DomainDriven.Sample.API.CargoManagement.Application.Dtos
{
    public class AddCargoInformationRequestDto
    {
        public int CustomerId { get; set; }
        public int OrderId { get; set; }
        public int CompanyId { get; set; }
    }
}
