using EmailSender.Configuration;
using EmailSender.Services;
using MailKit.Net.Smtp;
using MassTransit;
using MimeKit;
using System.ServiceProcess;
using System.Threading.Tasks;
using System.Timers;

namespace EmailSender
{
    public partial class EmailService : ServiceBase
    {
        private SmtpClientService _client;
        private IBusControl _busControl;
        public EmailService()
        {
            InitializeComponent();
            this.CanStop = true;
            this.CanPauseAndContinue = true;
            this.AutoLog = true;
            _client = DiContainer.GetService<SmtpClientService>();
            _busControl = Bus.Factory.CreateUsingRabbitMq(config =>
            {
                config.ReceiveEndpoint("mail-messages", e =>
                {
                    e.Consumer<EventConsumer>();
                });
            });
        }

        protected override void OnStart(string[] args)
        {
            _busControl.Start();           
        }

        protected override void OnStop()
        {
            _busControl.Stop();
            _client.CloseSmtpConnection();
        }
    }   
}
