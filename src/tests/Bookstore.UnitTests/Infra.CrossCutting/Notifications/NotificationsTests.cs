using Bookstore.Domain.Entities;
using Bookstore.Infra.CrossCutting.Notifications;

using FluentAssertions;

using Flunt.Notifications;

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xunit;

namespace Bookstore.UnitTests.Infra.CrossCutting.Notifications
{
    public class NotificationsTests
    {
        private NotificationContext GetNotificationContext() => new NotificationContext();

        [Fact]
        public void AddNotifications_FromInvalidDomain_ShouldBeSuccess()
        {
            var author = new Author(-1, "T", "t");
            var notificationContext = GetNotificationContext();
            notificationContext.AddNotifications(author.Notifications);

            notificationContext.Notifications.Should().BeEquivalentTo(author.Notifications);
        }

        [Fact]
        public void AddNotifications_FromValidDomain_ShouldBeSuccess()
        {
            var author = new Author(1, "Test", "test@test.com");
            var notificationContext = GetNotificationContext();
            notificationContext.AddNotifications(author.Notifications);

            notificationContext.Notifications.Should().BeEmpty();
        }

        [Fact]
        public void AddSingleNotification_ShouldBeSuccess_HasNotifications_ShouldBeTrue()
        {
            var notificationContext = GetNotificationContext();
            notificationContext.AddNotification("key", "message");
            notificationContext.HasNotifications.Should().BeTrue();
        }

        [Fact]
        public void AddSingleNotification_UsingKeyMessage_ShouldBeSuccess()
        {
            var expectedNotification = new Notification("key", "message");
            var notificationContext = GetNotificationContext();
            notificationContext.AddNotification("key", "message");
            notificationContext.Notifications.Should().ContainEquivalentOf(expectedNotification);
        }

        [Fact]
        public void AddSingleNotification_UsingNotification_ShouldBeSuccess()
        {
            var expectedNotification = new Notification("key", "message");
            var notificationContext = GetNotificationContext();
            notificationContext.AddNotification(new Notification("key", "message"));
            notificationContext.Notifications.Should().ContainEquivalentOf(expectedNotification);
        }
    }
}
