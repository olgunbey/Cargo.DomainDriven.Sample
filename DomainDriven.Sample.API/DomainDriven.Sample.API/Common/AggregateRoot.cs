namespace DomainDriven.Sample.API.Common
{
    public class AggregateRoot : IEntity
    {
        public AggregateRoot()
        {
            this.Id = Guid.NewGuid();
            _notifications = new();
        }
        private readonly List<ICustomizeNotification> _notifications;
        public IReadOnlyCollection<ICustomizeNotification> Notifications => _notifications;
        public Guid Id { get; set; }

        public void RaiseDomainEvent(ICustomizeNotification notification)
        {
            _notifications.Add(notification);
        }
        public void ClearDomainEvents()
        {
            _notifications.Clear();
        }
    }
}
