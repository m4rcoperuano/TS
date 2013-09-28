using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Domain.Interfaces;
using Domain.IServices;
using Domain.ViewModels;
using System.Linq;
using System.Collections.Generic;
using Microsoft.Practices.Unity;
using Timesheet.Controllers;
using System.Web.Mvc;

namespace Timesheet.Tests.Controllers
{
    [TestClass]
    public class ClientControllerTest
   {
        private IClientProfileVMServices ClientProfileVMService;
        private IMembership MembershipService;
        private IUserModelService UserModelService;
        private ClientController controller;
        
        [TestInitialize]
        public void ClientControllerTestStart()
        {
            IUnityContainer container = TestBootstrapper.Initialise();
            this.ClientProfileVMService = container.Resolve<IClientProfileVMServices>();
            this.MembershipService = container.Resolve<IMembership>(); 
            this.UserModelService = container.Resolve<IUserModelService>();
            controller = new ClientController(this.ClientProfileVMService, this.MembershipService, this.UserModelService);
        }

        [TestMethod]
        public void Create()
        {    
            ActionResult result = controller.Create();
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void PostCreate()
        {
            ClientProfileModel clientProfileModel = new ClientProfileModel();
            clientProfileModel.ClientName = "Hello";
            clientProfileModel.CompanyLocationId = 1;
            ActionResult result = controller.Create(clientProfileModel);

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Manage()
        {
            ViewResult view = this.controller.Manage() as ViewResult;
            Assert.IsNotNull(view);
        }

        [TestMethod]
        public void Edit()
        {
            ViewResult view = this.controller.Edit(1) as ViewResult;
            Assert.IsNotNull(view);
        }
    }
}
