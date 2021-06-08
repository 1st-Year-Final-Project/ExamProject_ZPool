using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MimeKit;
using ZPool.Services.Interfaces;

namespace ZPool.Services.EFServices
{
    public class EmailService : IEmailSender
    {
        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
			var message = new MimeMessage();
            message.From.Add(new MailboxAddress("ZPool Administration", "zpooladm@outlook.com"));
            message.To.Add(new MailboxAddress("", $"{email}"));
            message.Subject = $"{subject}";

            message.Body = new TextPart("plain")
            {
                Text = $"{htmlMessage}"
            };

            using (var client = new SmtpClient())
            {
                client.Timeout = 5000;
                try
                {
                    client.Connect("smtp-mail.outlook.com", 25, false);
                }
                catch (Exception ex)
                {
                    throw;
                }

                client.AuthenticationMechanisms.Remove("XOAUTH2");
                // Note: only needed if the SMTP server requires authentication
                client.Authenticate("zpooladm@outlook.com", "SuperSecret1!");

                client.Send(message);
                client.Disconnect(true);
            }

        }

    }
}
