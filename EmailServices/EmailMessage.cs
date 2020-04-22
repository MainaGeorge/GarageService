using System.Collections.Generic;
using System.Linq;
using MimeKit;

namespace SparkAuto.EmailServices
{
    public class EmailMessage
    {
        public string To { get; set; }
        public string Content { get; set; }
        public string Subject { get; set; }

        public EmailMessage(string to, string content, string subject)
        {

            To = to;
            Content = content;
            Subject = subject;
        }
    }
}
