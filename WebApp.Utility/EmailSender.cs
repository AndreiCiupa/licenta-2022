using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.AspNetCore.Identity.UI.Services;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApp.Utility
{
    public class EmailSender : IEmailSender
    {
        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            var emailToSend = new MimeMessage();
            emailToSend.From.Add(MailboxAddress.Parse("effie.waelchi@ethereal.email"));
            emailToSend.To.Add(MailboxAddress.Parse(email));
            emailToSend.Subject = subject;
            emailToSend.Body = new TextPart(MimeKit.Text.TextFormat.Html) { Text = htmlMessage };

            //send email
            using (var emailClient = new SmtpClient())
            {
                try
                {
                    await emailClient.ConnectAsync("smtp.ethereal.email", 587, SecureSocketOptions.StartTls);
                    await emailClient.AuthenticateAsync("effie.waelchi@ethereal.email", "PTjWwzCFgW4bnh5NcH");
                    await emailClient.SendAsync(emailToSend);
                }
                catch
                {
                    throw;
                }
                finally
                {
                    await emailClient.DisconnectAsync(true);
                    emailClient.Dispose();
                }
                

                
            }
            //return Task.CompletedTask;
        }
    }
}
