using DomainDriven.Sample.API.CargoManagement.Domain.Entities;
using MediatR;


namespace DomainDriven.Sample.API.CargoManagement.Domain.Aggregates
{
    public interface IAggregateRoot : IEntity
    {
        public List<INotification> Notifications { get; set; }
    }
}
