using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppMVC.Models;
using WebAppMVC.RestClients;
using WebAppMVC.Services;

namespace WebAppMVC.Controllers
{
    public class BillingController : Controller
    {
        private readonly IBillingTransactionsApi _billingTransactionsApi;
        private IEmail _email;
        public BillingController(IBillingTransactionsApi billingTransactionsApi, IEmail email)
        {
            _billingTransactionsApi = billingTransactionsApi ?? throw new ArgumentNullException(nameof(billingTransactionsApi));
            _email = email ?? throw new ArgumentNullException(nameof(email));
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
            _email.SendEmailFromGmail("Visitor Logged into Billing SPA", "");
            //list of ledger items
            var ledgerItems = await _billingTransactionsApi.GetAllTransactions();
            return View(ledgerItems);
        }
    }
}
