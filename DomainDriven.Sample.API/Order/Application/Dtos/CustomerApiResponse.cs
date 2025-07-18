namespace DomainDriven.Sample.API.Order.Application.Dtos
{
    public class CustomerApiResponse
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public int CurrentCityId { get; set; }
        public int CurrentDistrictId { get; set; }
        public string CurrentDetail { get; set; }
    }
}
