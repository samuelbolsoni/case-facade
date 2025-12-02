namespace CaseFacade.Services
{
    public class NotificationService
    {
        public void SendEmail(string email, string message)
        {
            Console.WriteLine($"[Email enviado para {email}] {message}");
        }
    }
}