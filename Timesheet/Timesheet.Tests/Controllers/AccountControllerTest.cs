using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Domain.Models;
using Domain;
using Timesheet.Services;
using Domain.IServices;
using AutoMapper;
using DataSource;
using Timesheet.Controllers;

namespace Timesheet.Tests.Controllers
{
    public class AccountImplementation : IAccountServices
    {

        public bool Success
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public string Message
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public LoginModel GetLoginModel()
        {
            throw new NotImplementedException();
        }

        public RegisterModel GetRegisterModel()
        {
            throw new NotImplementedException();
        }

        public bool RegisterUser(RegisterModel registerModel)
        {
            return true;
        }

        public bool LoginUser(LoginModel loginModel)
        {
            throw new NotImplementedException();
        }

        public bool ConfirmUser(string confirmationToken)
        {
            throw new NotImplementedException();
        }


        public void LogoutUser()
        {
            throw new NotImplementedException();
        }
    }


    [TestClass]
    public class AccountControllerTest
    {

        [TestMethod]
        public void Register()
        {            
            RegisterModel regModel = new RegisterModel();
            regModel.CompanyName = "Marcos Company";
            regModel.ConfirmPassword = "Marco123";
            regModel.Password = "Marco123";
            regModel.FirstName = "Marco";
            regModel.LastName = "Ledesma";

            IAccountServices accountService = new AccountImplementation();
            AccountController accountController = new AccountController(accountService);
            accountController.Register(regModel);            
            
        }

        [TestMethod]
        public void Login()
        {
            IAccountServices service = new AccountServices(new AccountMembership());
            LoginModel loginModel = new LoginModel();
            loginModel.Email = "marco.j.ledesma@gmail.com";
            loginModel.Password = "Castle12!";

            AuthConfig.RegisterAuth();
            bool success = service.LoginUser(loginModel);
            Assert.IsTrue(success);
        }
    }
}
