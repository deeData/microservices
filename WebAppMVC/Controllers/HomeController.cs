using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Operations;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using WebAppMVC.Models;
using WebAppMVC.Models.Auth;
using WebAppMVC.Services;
using WebAppMVC.Services.Authentication;

namespace WebAppMVC.Controllers
{
    public class HomeController : Controller
    {
        private IRegisterModel _registerModel;
        private readonly ILogger<HomeController> _logger;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly IConfiguration _configuration;
        private IEmail _email;
       
        private string WebAppUrl
        {
            get
            {
                if (_configuration == null) throw new InvalidOperationException("Configuration is null");
                return _configuration?.GetValue<string>("WebAppUrl");
            }
        }

        public HomeController(ILogger<HomeController> logger, IRegisterModel registerModel, SignInManager<IdentityUser> signInManager, 
            IConfiguration configuration, IEmail email)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _registerModel = registerModel ?? throw new ArgumentNullException(nameof(registerModel));
            _signInManager = signInManager ?? throw new ArgumentNullException(nameof(signInManager));
            //string webAppUrl = configuration.GetValue<string>("WebAppUrl");
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
            _email = email ?? throw new ArgumentNullException(nameof(email));

        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Logout()
        {
            _signInManager.SignOutAsync();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(Login model)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false);
                if (result.Succeeded)
                {
                    //send email notification that someone had logged in
                    return Redirect(Path.Combine(WebAppUrl, "Billing/Test"));
                }
                ModelState.AddModelError("", "Username or Password incorrect.");
            }
            return View();
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(Register model)
        {
            if (ModelState.IsValid)
            {
                var user = new IdentityUser()
                {
                    UserName = model.Email,
                    Email = model.Email,
                };

                IdentityResult result = await _registerModel.RegisterUser(user, model);

                if (result.Succeeded == false)
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                    return View();
                }
                return Redirect(Path.Combine(WebAppUrl, "Billing/Test"));
            }
            return View();

        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


    }
}
