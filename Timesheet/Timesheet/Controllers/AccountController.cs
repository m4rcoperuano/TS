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
                if (this.AccountService.LoginUser(loginModel))
                {
                    return RedirectToAction("Index", "Dashboard");
                }

                ViewBag.alertType = "error";
                ViewBag.alertMessage = this.AccountService.Message;
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
                if (this.AccountService.RegisterUser(registerModel))
                {
                    return RedirectToAction("Login", new
                    {
                        alertType="information",
                        alertMessage="Thanks for registering. Please check your email to confirm your account."
                    });
                }
                else
                {
                    ViewBag.alertType = "error";
                    ViewBag.alertMessage = this.AccountService.Message;
                }
            }
            return View(registerModel);
        }

        [HttpGet]
        public ActionResult Confirm(string confirmationToken)
        {
            if (this.AccountService.ConfirmUser(confirmationToken))
            {
                return RedirectToAction("Login", new
                {
                    alertType = "success",
                    alertMessage = "Account confirmed successfully! Please login below."
                });
            }
            else
            {
                return RedirectToAction("Login", new
                {
                    alertType="error",
                    alertMessage = "Could not confirm your account. Please contact us for assistance."
                });
            }
        }

        [HttpGet]
        public ActionResult Logout()
        {
            this.AccountService.LogoutUser();
            return RedirectToAction("Login", new
            {
                alertType="information",
                alertMessage="Successfully logged out."
            });
        }
    }
}
