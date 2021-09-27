using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppMVC.Models;

namespace WebAppMVC.RestClients
{
    //Using Refit library to automate serializations
    public interface IBillingTransactionsApi
    {
        //only thing needed by Refit to call API
        [Get(path: "/api/payment")]
        Task<List<LedgerItemDto>> GetAllTransactions();
    }
}