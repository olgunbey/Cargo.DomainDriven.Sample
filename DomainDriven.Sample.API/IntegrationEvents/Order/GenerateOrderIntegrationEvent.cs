namespace DomainDriven.Sample.API.IntegrationEvents.Order
{
    public record GenerateOrderIntegrationEvent
    {
        public string CityName { get; set; }
        public string DistrictName { get; set; }
        public string Detail { get; set; }

    }
}
