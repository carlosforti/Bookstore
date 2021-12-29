using Flunt.Notifications;

using System.Collections.Generic;

namespace Bookstore.Infra.CrossCutting.Notifications
{
    public interface INotificationContext
    {
        bool HasNotifications { get; }
        IReadOnlyCollection<Notification> Notifications { get; }

        void AddNotification(Notification notification);
        void AddNotification(string key, string message);
        void AddNotifications(IReadOnlyCollection<Notification> notifications);
    }
}