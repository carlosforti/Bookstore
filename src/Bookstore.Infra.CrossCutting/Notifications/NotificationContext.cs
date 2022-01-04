using Flunt.Notifications;

namespace Bookstore.Infra.CrossCutting.Notifications
{
    public class NotificationContext : INotificationContext
    {
        private readonly List<Notification> _notifications = new List<Notification>();
        public IReadOnlyCollection<Notification> Notifications => _notifications.AsReadOnly();
        public bool HasNotifications => _notifications.Any();

        public void AddNotification(string key, string message) => _notifications.Add(new Notification(key, message));
        public void AddNotification(Notification notification) => _notifications.Add(notification);
        public void AddNotifications(IReadOnlyCollection<Notification> notifications) => _notifications.AddRange(notifications);
    }
}
