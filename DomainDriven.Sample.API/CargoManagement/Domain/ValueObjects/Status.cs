namespace DomainDriven.Sample.API.CargoManagement.Domain.ValueObjects
{
    public class Status : ValueObject
    {
        public Status(StatusType statusType)
        {
            StatusType = statusType;
        }
        public StatusType StatusType { get; private set; }
    }
    public enum StatusType
    {
        Created,
        InTransit,
        Delivered,
        Cancelled
    }
}
