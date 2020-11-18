using EmailExchanging;
using MassTransit;
using System.Threading.Tasks;

namespace EmailSender.Services
{
    public class EventConsumer : IConsumer<EmailInputModel>
    {
        EmaiSenderService emaiSenderService;
        public async Task Consume(ConsumeContext<EmailInputModel> context)
        {
            emaiSenderService = new EmaiSenderService();
            emaiSenderService.SendEmail(context.Message);
        }
    }
}
