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
        public async Task Consume(ConsumeContext<EmailInputModel> context)
        {
            
        }
    }
}
