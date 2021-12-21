using Flunt.Notifications;

using System.Collections.Generic;
using System.Linq;

namespace Bookstore.Domain.ExtensionMethods
{
    internal static class NotificationExtensionMethods
    {
        public static IReadOnlyCollection<Notification> AddNotificationKeyPrefix(this IReadOnlyCollection<Notification> notifications, string keyPrefix)
            => notifications.Select(n => new Notification(string.Format(keyPrefix, n.Key), n.Message)).ToList();
    }
}
