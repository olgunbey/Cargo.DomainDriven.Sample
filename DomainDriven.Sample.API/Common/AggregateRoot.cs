using MediatR;


namespace DomainDriven.Sample.API.Common
{
    public class AggregateRoot : IEntity
    {
        public List<INotification> Notifications { get; set; }

        public int Id { get; private set; }
    }
}
