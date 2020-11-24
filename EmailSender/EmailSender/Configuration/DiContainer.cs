using EmailSender.Services;
using Microsoft.Extensions.DependencyInjection;

namespace EmailSender.Configuration
{
    public static class DiContainer
    {
        private static ServiceProvider _serviceProvider;
        static DiContainer()
        {
            _serviceProvider = new ServiceCollection()
                .AddSingleton<MailSettings>()
                .AddSingleton<SmtpClientService>()
            .BuildServiceProvider();
        }

        public static T GetService<T>() => _serviceProvider.GetService<T>();
    }
}
