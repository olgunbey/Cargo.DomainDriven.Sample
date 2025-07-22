using MediatR;

namespace DomainDriven.Sample.API.Common
{
    public interface ICustomizeNotification : INotification
    {
        public bool ShouldLogEvent { get; set; }
    }
}
