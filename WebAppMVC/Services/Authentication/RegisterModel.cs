using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppMVC.Models.Auth;
using Microsoft.AspNetCore.Identity;

namespace WebAppMVC.Services.Authentication
{
    public class RegisterModel : IRegisterModel
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;
        
        public Register Model { get; set; }

        public RegisterModel(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        public async Task<IdentityResult> RegisterUser(IdentityUser user, Register model) 
        {
            IdentityResult result = await userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                //false means not persistent after browser is closed
                await signInManager.SignInAsync(user, false);
            }
            return result;
        }
    }
}
