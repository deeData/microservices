using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppMVC.Models.Auth;

namespace WebAppMVC.Services.Authentication
{
    public interface IRegisterModel
    {
        public Task<IdentityResult> RegisterUser(IdentityUser user, Register model);
    }
}
