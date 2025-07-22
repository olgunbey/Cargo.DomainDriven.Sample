namespace DomainDriven.Sample.API.Common
{
    public class AggregateRoot : IEntity
    {
        public AggregateRoot()
        {
            _notifications = new();
        }
        public int Id { get; private set; }
        private readonly List<ICustomizeNotification> _notifications;
        public IReadOnlyCollection<ICustomizeNotification> Notifications => _notifications;
        protected void RaiseDomainEvent(ICustomizeNotification notification)
        {
            _notifications.Add(notification);
        }
        protected void ClearDomainEvents()
        {
            _notifications.Clear();
        }
    }
}
