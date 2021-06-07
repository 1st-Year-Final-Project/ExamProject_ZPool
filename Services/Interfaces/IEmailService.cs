using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZPool.Services.Interfaces
{
    public interface IEmailService
    {
        void SendConfirmationEmail(string email, string subject, string htmlMessage);
    }
}
