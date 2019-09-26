using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Net2._2Identity.Services
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string email, string subject, string message);
    }
}
