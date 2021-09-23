using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppMVC.Models;

namespace WebAppMVC.Controllers
{
    public class BillingController : Controller
    {
        List<LedgerItemDto> ledgerItems = new List<LedgerItemDto>()
            {
                new LedgerItemDto{ Posted =  new DateTime(2021, 9, 10), Description = "Charge", Debit = -45.99, Remarks = ""},
                new LedgerItemDto{ Posted = new DateTime(2021, 9, 15), Description = "Payment", Credit = 5.00, Remarks = "Order#123"},
                new LedgerItemDto{ Posted = DateTime.Now, Description = "Charge", Debit = -1.99, Remarks = "Card# 123"},
            };

        [HttpGet]
        public IActionResult Payment()
        {
            return View(ledgerItems);
        }

        [HttpGet]
        public IActionResult Test()
        {
            return View(ledgerItems);
        }
    }
}
