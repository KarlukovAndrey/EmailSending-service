using EmailExchanging;
using EmailSender.Configuration;
using MailKit.Net.Smtp;
using MimeKit;

namespace EmailSender
{
    public class EmaiSenderService
    {
        MailSettings  _mailSettings;
        public EmaiSenderService()
        {
            _mailSettings = DiContainer.GetService<MailSettings>();
        }
        public void SendEmail(EmailInputModel _emailInputModel)
        {
            var emailMessage = new MimeMessage();

            emailMessage.From.Add(new MailboxAddress(_mailSettings.SenderName, _mailSettings.SenderEmail));
            emailMessage.To.Add(new MailboxAddress("", _emailInputModel.Email));
            emailMessage.Subject = _mailSettings.MessageHeader;
            emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            {
                Text = _emailInputModel.Message
            };
            using (var client = new SmtpClient())
            {
                client.Connect(_mailSettings.SmtpServer, _mailSettings.Port, false);
                client.Authenticate(_mailSettings.SenderEmail, _mailSettings.Password);
                client.Send(emailMessage);
                client.Disconnect(true);
            }
        }      
    }
}
