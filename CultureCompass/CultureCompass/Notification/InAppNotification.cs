using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Maui.Core.Views;
using Plugin.LocalNotification;


namespace CultureCompass.Notification
{
    internal class InAppNotification : INotificationType
    {
        public void SendNotification(string title, string description)
        {
            var snackbar = Snackbar.Make(title, null,"OK",TimeSpan.FromSeconds(5), new SnackbarOptions
            {
                BackgroundColor = Colors.Red,
                TextColor = Colors.White,
                CornerRadius = 10
            });
            snackbar.Show();
        }
    }
}
