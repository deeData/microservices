using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppMVC.Models
{
    public class PaymentDto
    {
        public string ClientSecret { get; set; }
        public string CardNumber { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
        public string CVC { get; set; }
        public int AmountInCents { get; set; }
        //public int PaymentId { get; set; }
        //public DateTime PaymentDate { get; set; }
        //public double PaymentAmount { get; set; }
        //public string PaymentType { get; set; }
        //public string PaymentSource { get; set; }
    }
}
