using CultureCompass.Notification;
using Plugin.LocalNotification;

namespace CultureCompass
{
    public partial class MainPage : ContentPage
    {
        NotificationManager notificationManager = new NotificationManager();
        public MainPage()
        {
            InitializeComponent();
            notificationManager.NotificationType = new InAppNotification();
        }

        private async void OnCounterClicked(object sender, EventArgs e)
        {

            notificationManager.SendNotification("Thijme", "dit is een test");

            notificationManager.NotificationType = new PushNotification();

        }
    }

}
