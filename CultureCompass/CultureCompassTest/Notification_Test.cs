using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CultureCompassTest
{
    public class Notification_Test
    {
        [Fact]
        public void SetNotificationType_ChangesTypeAsExpected_Test()
        {
            // Arrange
            Mock<INotificationType> mock = new Mock<INotificationType>();
            NotificationManager notificationManager = new();
            notificationManager.NotificationType = mock.Object;

            // Act
            notificationManager.NotificationType = new PushNotification();

            // Assert
            Assert.IsType<PushNotification>(notificationManager.NotificationType);

            // Act
            notificationManager.NotificationType = new InAppNotification();

            // Assert
            Assert.IsType<InAppNotification>(notificationManager.NotificationType);
        }

        [Fact]
        public void InitializeNotificationType_NotNull_Test()
        {
            // Arrange
            NotificationManager notificationManager = new();

            // Assert
            Assert.NotNull(notificationManager.NotificationType);
        }

        [Fact]
        public void InitializeNotificationManager_WithSpecificType_Test()
        {
            // Arrange
            NotificationManager notificationManager = new();
            INotificationType notificationType = new PushNotification();

            // Act
            notificationManager.NotificationType = notificationType;

            // Assert
            Assert.Equal(notificationType, notificationManager.NotificationType);
        }

        [Fact]
        public void CheckIfPermissionIsDefaultDenied_Test()
        {
            // Arrange
            NotificationManager notificationManager = new();

            // Assert
            Assert.False(notificationManager.IsPermissionGranted());
        }
    }
}
