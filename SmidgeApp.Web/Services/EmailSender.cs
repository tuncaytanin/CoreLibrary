using Microsoft.Extensions.Configuration;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmidgeApp.Web.Services
{
    public class EmailSender : IEmailSender
    {
        private readonly IConfiguration _configuration;

        public EmailSender(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task Sender(string UserId, string message)
        {
            var apiKey = _configuration.GetSection("APIs")["SendGridApi"];
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress("tuncaytnn@gmail.com", "Example User");
            var subject = "Site Bilgilendirme";
            var to = new EmailAddress("tuncaytanin@live.com", "Example User");
          //  var plainTextContent = "and easy to do anywhere, even with C#";
            var htmlContent = $"<strong> {message} </strong>";
            var msg = MailHelper.CreateSingleEmail(from, to, subject, null, htmlContent);
              await client.SendEmailAsync(msg);

        }
    }
}
