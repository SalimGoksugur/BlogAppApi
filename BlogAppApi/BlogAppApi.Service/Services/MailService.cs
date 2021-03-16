using BlogAppApi.Core.IServices;
using Microsoft.Extensions.Configuration;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BlogAppApi.Service.Services
{
    public class MailService : IMailService
    {
        private readonly IConfiguration _configuration;

        public MailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task SendMail(string toEmail, string subject, string content)
        {

            var apiKey = _configuration["SendGridApiKey"];
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress("salimgoksugur@gmail.com", "Salim");
            var subjectOfMail = subject;
            var to =new EmailAddress( toEmail);

            var htmlContent = $"<strong>{content} </strong>";
            
            var msg = MailHelper.CreateSingleEmail(from, to, subjectOfMail,content, htmlContent);
            var response = await client.SendEmailAsync(msg);
        }
    }
}
