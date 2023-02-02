using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoggingAssignment.Services
{
    internal static class MailService
    {
        public static void SendEmail(string subject, string body, string recipient)
        {
            // This is just sample method that would send email into customer
        }

        internal static void SendEmail(string v1, string v2, object email)
        {
            throw new NotImplementedException();
        }
    }
}
