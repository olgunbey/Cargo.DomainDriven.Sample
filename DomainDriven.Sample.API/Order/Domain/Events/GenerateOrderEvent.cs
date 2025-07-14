using MediatR;

namespace DomainDriven.Sample.API.Order.Domain.Events
{
    public record GenerateOrderEvent : INotification
    {
        public int CityId { get; set; }
        public int DistrictId { get; set; }
        public string Detail { get; set; }
        public int EmployeeId { get; set; }
    }
}
