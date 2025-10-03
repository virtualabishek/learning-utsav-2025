namespace LearningUtsav
{
    public delegate void NotificationHandler(string message);
    public class Publisher
    {
        public event NotificationHandler OnAlert;
        public void RaiseAlert(string msg)
        {
            Console.WriteLine($"Alert raised: {msg}");
            OnAlert?.Invoke(msg);
        }
    }

    // subscriber 1 
    public class Logger
    {
        public void Log(string msg) => Console.WriteLine($"LOG: {msg}");

    }

    public class Emailer
    {
        public void SendEmail(string msg) => Console.WriteLine($"EMAIL: {msg} sent!");
    }

}