﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plugin.LocalNotification;

namespace CultureCompass.Notification
{
    internal interface INotificationType
    {
        NotificationRequest SendNotification(string text);
    }
}
