using DomainDriven.Sample.API.CargoManagement.Domain.Entities;
using MediatR;


namespace DomainDriven.Sample.API.CargoManagement.Domain.Aggregates
{
    public class AggregateRoot : IEntity
    {
        public List<INotification> Notifications { get; set; }

        public int Id { get; private set; }
    }
}
