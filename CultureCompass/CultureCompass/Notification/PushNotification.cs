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
        public NotificationRequest SendNotification(string text)
        {
            return new NotificationRequest
            {
                NotificationId = 1337,
                Title = $"Close to waypoint: {text}",
                Description = "Information here",
                BadgeNumber = 42,
                Schedule = new NotificationRequestSchedule
                {
                    NotifyTime = DateTime.Now.AddSeconds(5),
                },
                Android = new AndroidOptions
                {
                    Color = new AndroidColor(150)
                }
            };
          
        }
    }
}
