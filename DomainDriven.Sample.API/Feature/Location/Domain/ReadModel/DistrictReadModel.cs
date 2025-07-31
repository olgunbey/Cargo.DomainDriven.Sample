namespace DomainDriven.Sample.API.Feature.Location.Domain.ReadModel
{
    public class DistrictReadModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid CityId { get; set; }
    }
}
