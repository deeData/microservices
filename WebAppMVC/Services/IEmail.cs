using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppMVC.Services
{
    public interface IEmail
    {
        public void SendEmailFromGmail(string emailSubject, string emailBody);
    }
}
