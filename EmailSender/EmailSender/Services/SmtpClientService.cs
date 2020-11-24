using EmailSender.Configuration;
using MimeKit;
using MailKit.Net.Smtp;

namespace EmailSender.Services
{
    public class SmtpClientService
    {
        private SmtpClient _client;
        private MailSettings _mailSettings;
        public SmtpClientService()
        {
            _mailSettings = DiContainer.GetService<MailSettings>();
            _client = new SmtpClient();
            _client.Connect(_mailSettings.SmtpServer, _mailSettings.Port, false);
            _client.Authenticate(_mailSettings.SenderEmail, _mailSettings.Password);
        }
        public void SendMessage(MimeMessage message)
        {
            _client.Send(message);
        }
        public void CloseSmtpConnection()
        {
            _client.Disconnect(true);
        }
    }
}
