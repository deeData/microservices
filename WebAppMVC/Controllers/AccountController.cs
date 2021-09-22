using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using WebAppMVC.Models;

namespace WebAppMVC.Controllers
{
    public class AccountController : Controller
    {
        List<LedgerItemDto> ledgerItems = new List<LedgerItemDto>() 
            { 
                new LedgerItemDto{ Posted =  new DateTime(2021, 9, 10), Description = "Charge", Debit = -45.99, Remarks = ""},
                new LedgerItemDto{ Posted = new DateTime(2021, 9, 15), Description = "Payment", Credit = 5.00, Remarks = "Order#123"},
                new LedgerItemDto{ Posted = DateTime.Now, Description = "Charge", Debit = -1.99, Remarks = "Card# 123"},
            };
        

        //render Stripe's payment widget
        [HttpGet]
        public IActionResult Payment()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Ledger()
        {
            return View(ledgerItems);
        }

        [HttpGet]
        public IActionResult Test()
        {
            return View();
        }


    }
}
