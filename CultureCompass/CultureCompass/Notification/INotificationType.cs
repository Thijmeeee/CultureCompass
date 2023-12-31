﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plugin.LocalNotification;

namespace CultureCompass.Notification
{
    public interface INotificationType
    {
        void SendNotification(string text, string description);
        bool IsPermissionGranted();
    }
}
