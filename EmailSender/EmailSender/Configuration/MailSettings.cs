using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailSender.Configuration
{
    public class MailSettings
    {
        public string SenderName = ConfigurationManager.AppSettings["SenderName"];

        public string SenderEmail = ConfigurationManager.AppSettings["SenderEmail"];

        public string Password =  ConfigurationManager.AppSettings["Password"];

        public string SmtpServer =  ConfigurationManager.AppSettings["SmtpServer"];

        public int Port = Convert.ToInt32(ConfigurationManager.AppSettings["Port"]);

        public string MessageHeader =  ConfigurationManager.AppSettings["MessageHeader"];
    }
}
