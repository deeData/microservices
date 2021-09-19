using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppMVC.Services.IServices
{
    interface IPayment
    {
        //create the customer account in payment processor vendor
        Task<T> CreateCustomerAccount<T>(object customerInfo);
        //set up intent for future payments to customer account
        Task<T> SetupIntent<T>(object customerInfo);
        //add-update customer payment data 
        Task<bool> CreateUpdatePaymentInfo(object paymentInfo);
        //charge customer 
        Task<bool> ProcessPayment(object customerInfo);
    }
}
