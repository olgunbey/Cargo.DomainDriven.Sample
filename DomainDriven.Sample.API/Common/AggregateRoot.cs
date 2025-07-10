using MediatR;


namespace DomainDriven.Sample.API.Common
{
    public class AggregateRoot : IEntity
    {
        public AggregateRoot()
        {
            _notifications = new();
        }
        public int Id { get; private set; }
        private readonly List<INotification> _notifications;
        public IReadOnlyCollection<INotification> Notifications => _notifications;
        protected void RaiseDomainEvent(INotification notification)
        {
            _notifications.Add(notification);
        }
        protected void ClearDomainEvents()
        {
            _notifications.Clear();
        }
    }
}
