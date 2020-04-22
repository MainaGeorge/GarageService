using System.Threading.Tasks;

namespace SparkAuto.EmailServices
{
    public interface IEmailSender
    {
        void SendEmail(EmailMessage emailMessage);
        Task SendEmailAsync(EmailMessage emailMessage);
    }
}
