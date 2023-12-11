using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plugin.LocalNotification;

namespace CultureCompass.Notification
{
    internal class NotificationManager
    {
        public INotificationType NotificationType { get; set; }

        public NotificationManager()
        {
            NotificationType = new PushNotification();
        }

        public void SetStrategy(INotificationType notificationType)
        {
            NotificationType = notificationType;
        }

        public NotificationRequest SendNotification(string text)
        {
            return NotificationType.SendNotification(text);
        }

       

        

    }

}
