using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppMVC.Models;
using WebAppMVC.RestClients;

namespace WebAppMVC.Controllers
{
    public class BillingController : Controller
    {
        private readonly IBillingTransactionsApi _billingTransactionsApi;
        public BillingController(IBillingTransactionsApi billingTransactionsApi)
        {
            _billingTransactionsApi = billingTransactionsApi;
        }

        [HttpGet]
        public IActionResult Payment()
        {
            return View();
        }

        [Microsoft.AspNetCore.Authorization.Authorize]
        [HttpGet]
        public async Task<IActionResult> Test()
        {
            //list of ledger items
            var ledgerItems = await _billingTransactionsApi.GetAllTransactions();
            return View(ledgerItems);
        }
    }
}
