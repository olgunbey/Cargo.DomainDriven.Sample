namespace DomainDriven.Sample.API.Feature.Location.Domain.ReadModels
{
    public class CustomerOrderTargetLocationReadModel
    {
        public Guid Id { get; set; }
        public Guid CustomerId { get;  set; }
        public string LocationHeader { get;  set; }
        public Guid CityId { get;  set; }
        public string CityName { get; set; }
        public Guid DistrictId { get;  set; }
        public string DistrictName { get; set; }
        public string Detail { get;  set; }

    }
}
