namespace DesignPrinciples_LooseVsTightCoupling
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var serviceMode = NotificationModelFactor.Create(NotificationMode.EMAIL);
            NotificationService notificationService = new NotificationService(serviceMode);
            notificationService.Notify();
            Console.ReadKey();
        }
    }
    class NotificationModelFactor
    {
        public static INotificationMode Create(NotificationMode mode)
        {
            switch (mode)
            {
                case NotificationMode.EMAIL:
                    return new EmailService();
                case NotificationMode.SMS:
                    return new SMSService();
                default:
                    return new EmailService();
            }
        }
    }
    enum NotificationMode
    {
        EMAIL,
        SMS,
    }
    interface INotificationMode
    {
        void send();
    }
    class EmailService : INotificationMode
    {
        public void send()
        {
            Console.WriteLine("Email Sent");
        }
    }
    class SMSService : INotificationMode
    {
        public void send()
        {
            Console.WriteLine("SMS Sent");
        }
    }
    class NotificationService
    {
        private readonly INotificationMode _notificationMode;
        public NotificationService(INotificationMode notificationMode)
        {
            _notificationMode = notificationMode;
        }
        public void Notify()
        {
            _notificationMode.send();
        }
    }
}