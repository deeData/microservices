using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace WebAppMVC.Services
{
    public class Email : IEmail
    {
        private readonly IConfiguration _configuration;

        public Email(IConfiguration configuration)
        {
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }

        //needed to enable IMAP and allow unsecure apps in Gmail Settings
        public void SendEmailFromGmail(string emailSubject, string emailBody)
        {
            var fromEmail = _configuration.GetSection("Email").GetValue<string>("FromGoogleEmail");
            var passwordFromEmail = _configuration.GetSection("Email").GetValue<string>("PasswordFromGoogleEmail");
            var toEmail = _configuration.GetSection("Email").GetValue<string>("ToEmail");

            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);

            try
            {
                smtp.EnableSsl = true;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential(fromEmail, passwordFromEmail);
                MailMessage emailObj = new MailMessage(fromEmail, toEmail);
                emailObj.Subject = emailSubject;
                emailObj.Body = emailBody;
                smtp.Send(emailObj);

            }
            catch (Exception)
            {
                throw new Exception(emailBody.ToString());
            }

        }
    }
}
