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
            notificationManager.SetStrategy(new PushNotification());
        }

        private async void OnCounterClicked(object sender, EventArgs e)
        {
            var request = notificationManager.SendNotification("Thijme");

            Task<bool> enabled = LocalNotificationCenter.Current.AreNotificationsEnabled();

            if (!enabled.Result)
            {
                await LocalNotificationCenter.Current.RequestNotificationPermission();
            }
            await LocalNotificationCenter.Current.Show(request);
        }
    }

}
