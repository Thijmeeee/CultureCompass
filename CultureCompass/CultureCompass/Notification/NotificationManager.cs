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

        

    }

}
