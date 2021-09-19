using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppMVC.Services.IServices;

namespace WebAppMVC.Services
{
    public class Payment : IPayment
    {
        public Task<T> CreateCustomerAccount<T>(object customerInfo)
        {
            throw new NotImplementedException();
        }

        public Task<bool> CreateUpdatePaymentInfo(object paymentInfo)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ProcessPayment(object customerInfo)
        {
            throw new NotImplementedException();
        }

        public Task<T> SetupIntent<T>(object customerInfo)
        {
            throw new NotImplementedException();
        }
    }
}
