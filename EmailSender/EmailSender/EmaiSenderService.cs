using EmailExchanging;
using MailKit.Net.Smtp;
using MimeKit;

namespace EmailSender
{
    public class EmaiSenderService
    {     
        public void SendEmail(EmailInputModel _emailInputModel)
        {
            var emailMessage = new MimeMessage();

            emailMessage.From.Add(new MailboxAddress("DevEducation", "ruberd724@gmail.com"));
            emailMessage.To.Add(new MailboxAddress("", _emailInputModel.Email));
            emailMessage.Subject = "Тест";
            emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            {
                Text = _emailInputModel.Message
            };
            using (var client = new SmtpClient())
            {
                client.Connect("smtp.gmail.com", 587, false);

                client.Authenticate("ruberd724@gmail.com", "!@14kLm703");
                client.Send(emailMessage);

                client.Disconnect(true);
            }
        }      
    }
}
