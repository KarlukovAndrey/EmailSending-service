using MailKit.Net.Smtp;
using MimeKit;
using System.ServiceProcess;
using System.Threading.Tasks;
using System.Timers;

namespace EmailSender
{
    public partial class Service2 : ServiceBase
    {
        Logger logger;
        public Service2()
        {
            InitializeComponent();
            this.CanStop = true;
            this.CanPauseAndContinue = true;
            this.AutoLog = true;
        }

        protected override void OnStart(string[] args)
        {
            logger = new Logger();
            logger.Start();
        }

        protected override void OnStop()
        {
            logger.Stop();
        }
    }
    class Logger
    {
        Timer timer;

        public Logger()
        {
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
