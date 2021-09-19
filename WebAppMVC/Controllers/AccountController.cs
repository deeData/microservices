using Microsoft.AspNetCore.Mvc;
using Stripe;
using System;
using System.ComponentModel.DataAnnotations;
using System.IO;

namespace WebAppMVC.Controllers
{
    public class AccountController : Controller
    {
        //render Stripe's payment widget
        [HttpGet]
        public IActionResult Payment()
        {
            return View();
        }


    }
}
