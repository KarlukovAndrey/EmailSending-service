using EmailExchanging;
using EmailSender.Configuration;
using MailKit.Net.Smtp;
using MimeKit;

namespace EmailSender.Services
{
    public class EmaiSenderService
    {
        MailSettings _mailSettings;
        SmtpClientService _client;
        
        public EmaiSenderService()
        {
            _mailSettings = DiContainer.GetService<MailSettings>();
            _client = DiContainer.GetService<SmtpClientService>();
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
            
            _client.SendMessage(emailMessage);
            
        }
    }
}
