﻿using System;
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

        public async void SendNotification(string text, string description)
        {
           

            NotificationType.SendNotification(text, description);
        }
    }

}
