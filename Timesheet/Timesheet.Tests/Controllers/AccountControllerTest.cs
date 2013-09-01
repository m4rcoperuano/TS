using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Domain.Models;
using Domain;
using Domain.Services;
using Domain.IServices;
using AutoMapper;
using DataSource;

namespace Timesheet.Tests.Controllers
{
    [TestClass]
    public class AccountControllerTest
    {
        [TestMethod]
        public void Register()
        {
            IAccountServices service = new AccountServices();
            RegisterModel regModel = new RegisterModel();
            regModel.CompanyName = "Marcos Company";
            regModel.ConfirmPassword = "Marco123";
            regModel.Password = "Marco123";
            regModel.FirstName = "Marco";
            regModel.LastName = "Ledesma";

            Bootstrapper.RegisterMapper();
            var success = service.RegisterUser(regModel);

            Assert.IsTrue(success);
        }
    }
}
