using MediatR;

namespace DomainDriven.Sample.API.CargoManagement.Domain.Events
{
    public class GenerateCargoEvent : INotification
    {
        public GenerateCargoEvent(string detail, string cargoCode)
        {
            this.Detail = detail;
            this.CargoCode = cargoCode;
        }
        public string Detail { get; private set; }
        public string CargoCode { get; private set; }
    }
}
