
using DomainDriven.Sample.API.Common;

namespace DomainDriven.Sample.API.CargoManagement.Domain.ValueObjects
{
    public class Status : ValueObject
    {
        public Status(StatusType statusType)
        {
            StatusType = statusType;
        }
        public StatusType StatusType { get; private set; }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return StatusType;
        }
    }
    public enum StatusType
    {
        Created,
        InTransit,
        Delivered,
        Cancelled
    }
}
