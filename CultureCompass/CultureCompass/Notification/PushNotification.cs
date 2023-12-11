using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plugin.LocalNotification;
using Plugin.LocalNotification.AndroidOption;

namespace CultureCompass.Notification
{
    internal class PushNotification : INotificationType
    {
        public void SendNotification(string title, string description)
        {
            CheckPermissionOfUser();

            var request = new NotificationRequest
            {
                NotificationId = 1337,
                Title = $"Close to waypoint: {title}",
                Description = description,
                BadgeNumber = 42,
                Schedule = new NotificationRequestSchedule
                {
                    NotifyTime = DateTime.Now.AddSeconds(5),
                },
                Android = new AndroidOptions
                {
                    Color = new AndroidColor(255)
                }
            };
           LocalNotificationCenter.Current.Show(request);
        }
        private async void CheckPermissionOfUser()
        {
            var enabled = LocalNotificationCenter.Current.AreNotificationsEnabled().Result;

            if (!enabled)
            {
                await LocalNotificationCenter.Current.RequestNotificationPermission();
            }
        }
    }
}
