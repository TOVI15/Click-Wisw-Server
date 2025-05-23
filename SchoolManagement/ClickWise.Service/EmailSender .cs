using ClickWise.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using Microsoft.Extensions.Configuration;

using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net;

namespace ClickWise.Service
{
    public class EmailSender : IEmailSender
    {
        private readonly IConfiguration _configuration;

        public EmailSender(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task SendEmailAsync(string to, string subject, string body)
        {

            var email = _configuration["EmailSettings:Username"];
            var password = _configuration["EmailSettings:Password"];
            var smtpClient = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                Credentials = new NetworkCredential(email, password),
                EnableSsl = true
            };

            var mailMessage = new MailMessage
            {
                From = new MailAddress(email),
                Subject = subject,
                Body = body,
                IsBodyHtml = true
            };

            mailMessage.To.Add(to);

            try
            {
                await smtpClient.SendMailAsync(mailMessage);
            }
            catch (SmtpException ex)
            {
                throw new Exception($"שגיאה בשליחת המייל: {ex.StatusCode}, פירוט: {ex.Message}");
            }
        }
    }



    //public async Task SendEmailAsync(string to, string subject, string body)
    //    {
    //        var email = new
    //        {
    //            service_id = _emailJsServiceId,
    //            template_id = _emailJsTemplateId,
    //            user_id = _emailJsUserId,
    //            template_params = new
    //            {
    //                to_email = to,
    //                subject = subject,
    //                body = body
    //            }
    //        };

    //        var client = new HttpClient();
    //        var response = await client.PostAsJsonAsync("https://api.emailjs.com/api/v1.0/email/send", email);

    //        if (!response.IsSuccessStatusCode)
    //        {
    //            var errorContent = await response.Content.ReadAsStringAsync();
    //            throw new Exception($"שגיאה בשליחת המייל: קוד {response.StatusCode}, פירוט: {errorContent}");
    //        }
    //    }
    //}
}
