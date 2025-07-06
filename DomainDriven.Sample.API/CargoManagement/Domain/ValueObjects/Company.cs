namespace DomainDriven.Sample.API.CargoManagement.Domain.ValueObjects
{
    public class Company : ValueObject
    {
        public string Code { get; private set; }
        public string Name { get; private set; }
    }
}
