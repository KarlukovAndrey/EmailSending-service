using System.ServiceProcess;

namespace EmailSender
{
    static class Program
    {     
        static void Main()
        {
            ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[]
            {
                new EmailService()
            };
            ServiceBase.Run(ServicesToRun);
        }
    }
}
