using EmailSender.Services;
using MailKit.Net.Smtp;
using MassTransit;
using MimeKit;
using System.ServiceProcess;
using System.Threading.Tasks;
using System.Timers;

namespace EmailSender
{
    public partial class Service2 : ServiceBase
    {
        EmaiSenderService sender;
        private IBusControl _busControl;
        public Service2()
        {
            InitializeComponent();
            this.CanStop = true;
            this.CanPauseAndContinue = true;
            this.AutoLog = true;
        }

        protected override void OnStart(string[] args)
        {
            _busControl = Bus.Factory.CreateUsingRabbitMq(config =>
            {               
                config.ReceiveEndpoint("mail-receiver", e =>
                {
                    e.Consumer<EventConsumer>();
                });
            });
            sender.Start();
        }

        protected override void OnStop()
        {
            sender.Stop();
        }
    }
   
}
