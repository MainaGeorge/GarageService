using System;
using System.Threading.Tasks;
using MailKit.Net.Smtp;
using MimeKit;

namespace SparkAuto.EmailServices
{
    public class EmailSender : IEmailSender
    {
        private readonly EmailConfigurations _config;

        public EmailSender(EmailConfigurations config)
        {
            _config = config;
        }
        public void SendEmail(EmailMessage message)
        {
            var emailMessage = CreateEmailMessage(message);
            Send(emailMessage);
        }

        public async Task SendEmailAsync(EmailMessage emailMessage)
        {
            var mailMessage = CreateEmailMessage(emailMessage);
            await SendAsync(mailMessage);
        }

        private MimeMessage CreateEmailMessage(EmailMessage message)
        {
            var emailMessage = new MimeMessage();
            emailMessage.From.Add(new MailboxAddress(_config.From));
            emailMessage.To.Add(new MailboxAddress(message.To));
            emailMessage.Subject = message.Subject;
            emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Text) { Text = message.Content };

            return emailMessage;
        }

        private async Task SendAsync(MimeMessage mailMessage)
        {
            using var client = new SmtpClient();
            try
            {
                await client.ConnectAsync(_config.SmtpServer, _config.Port, true);
                client.AuthenticationMechanisms.Remove("XOAUTH2");
                await client.AuthenticateAsync(_config.UserName, _config.Password);

                await client.SendAsync(mailMessage);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;

            }
            finally
            {
                await client.DisconnectAsync(true);
                client.Dispose();

            }
        }

        private void Send(MimeMessage emailMessage)
        {
            using var client = new SmtpClient();
            try
            {
                client.Connect(_config.SmtpServer, _config.Port, true);
                client.AuthenticationMechanisms.Remove("XOAUTH2");
                client.Authenticate(_config.UserName, _config.Password);

                client.Send(emailMessage);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            finally
            {
                client.Disconnect(true);
                client.Dispose();
            }
        }


    }
}
