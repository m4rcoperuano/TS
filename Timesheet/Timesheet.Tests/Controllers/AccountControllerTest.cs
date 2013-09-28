using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Domain.ViewModels;
using Domain;
using Domain.Services;
using Domain.IServices;
using Timesheet.Services;
using AutoMapper;
using DataAccessLayer;
using Timesheet.Controllers;
using Timesheet.Core.Interfaces;
using Timesheet.Core.Services;

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
            IRepository repository = new Repository();
            IMembership membership = new Membership(repository);

            IAccountServices service = new AccountServices(membership, repository);
            LoginModel loginModel = new LoginModel();
            loginModel.Email = "marco.j.ledesma@gmail.com";
            loginModel.Password = "Castle12!";

            AuthConfig.RegisterAuth();
            bool success = service.LoginUser(loginModel);
            Assert.IsTrue(success);
        }
    }
}
