namespace DomainDriven.Sample.API.Feature.Cargo.Application.Dtos
{
    public class CargoGetByCargoCodeResponseDto
    {
        public Guid CargoId { get; set; }
        public List<OrderDetailResponseDto> OrderDetailResponse { get; set; }
        public string CargoCode { get; set; }
    }
    public class OrderDetailResponseDto
    {
        public Guid ProductId { get; set; }
        public string ProductName { get; set; }
        public string CityName { get; set; }
        public string DistrictName { get; set; }
        public string Detail { get; set; }
    }

}
