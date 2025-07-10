using DomainDriven.Sample.API.Common;

namespace DomainDriven.Sample.API.CargoManagement.Domain.Aggregates
{
    public class CargoDetailInformation : AggregateRoot
    {
        public string Detail { get; private set; }
        public string CargoCode { get; private set; }
        public CargoDetailInformation GenerateCargoDetailInformation(string detail, string cargoCode)
        {
            if (string.IsNullOrEmpty(detail))
            {
                throw new ArgumentException("Detail cannot be null or empty.", nameof(Detail));
            }
            if (string.IsNullOrEmpty(cargoCode))
            {
                throw new ArgumentException("CargoCode cannot be null or empty.", nameof(CargoCode));
            }
            this.Detail = detail;
            this.CargoCode = cargoCode;
            return this;
        }
    }
}
