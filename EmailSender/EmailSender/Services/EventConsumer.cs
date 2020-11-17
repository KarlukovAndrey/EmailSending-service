using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailSender.Services
{
    public class EventConsumer : IConsumer<EmailInputModel>
    {
        EmaiSenderService emaiSenderService;
        public async Task Consume(ConsumeContext<EmailInputModel> context)
        {
            emaiSenderService = new EmaiSenderService(context.Message);
            emaiSenderService.SendEmail();
        }
    }
}
