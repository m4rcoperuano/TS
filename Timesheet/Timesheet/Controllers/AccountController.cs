using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domain.Models;
using Domain.IServices;

namespace Timesheet.Controllers
{
    public class AccountController : Controller
    {
        private IAccountServices AccountService;
        public AccountController(IAccountServices AccountService)
        {
            this.AccountService = AccountService;
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginModel loginModel)
        {
            if (ModelState.IsValid)
            {
                this.AccountService.LoginUser(loginModel);
            }
            return View(loginModel);
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterModel registerModel)
        {
            if (ModelState.IsValid)
            {
                this.AccountService.RegisterUser(registerModel);
            }
            return View();
        }
    }
}
