using EmailSender.Services;
using MailKit.Net.Smtp;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace EmailSender
{
    public class EmaiSenderService
    {
        Timer timer;
        EmailInputModel _emailInputModel;
        public EmaiSenderService(EmailInputModel emailInputModel)
        {
            _emailInputModel = emailInputModel;
            timer = new Timer(10000);
            timer.Elapsed += SendEmail;
            timer.AutoReset = true;
            timer.Enabled = true;
        }
        public void SendEmail(object source = null, ElapsedEventArgs e = null)
        {
            var emailMessage = new MimeMessage();

            emailMessage.From.Add(new MailboxAddress("DevEducation", "ruberd724@gmail.com"));
            emailMessage.To.Add(new MailboxAddress("", "karl911291@mail.ru"));
            emailMessage.Subject = "Тест";
            emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            {
                Text = "<h1>Привет Андрей!</h1>"
            };

            using (var client = new SmtpClient())
            {
                client.Connect("smtp.gmail.com", 587, false);
                client.Authenticate("ruberd724@gmail.com", "!@14kLm703");
                client.Send(emailMessage);

                client.Disconnect(true);
            }
        }
        public void Start()
        {
            timer.Enabled = true;
            timer.Start();
        }

        public void Stop()
        {
            timer.Stop();
            timer.Enabled = false;
        }
    }
}
