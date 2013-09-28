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
    public class ProjectControllerTest
   {
        private IProjectService ProjectService;        
        private ProjectController controller;
        
        [TestInitialize]
        public void ClientControllerTestStart()
        {
            IUnityContainer container = TestBootstrapper.Initialise();
            this.ProjectService = container.Resolve<IProjectService>();            
            this.controller = new ProjectController(this.ProjectService);
        }

        [TestMethod]
        public void Create()
        {
            ProjectModel projectModel = new ProjectModel();
            projectModel.ClientId = 1;
            projectModel.Created = DateTime.Now;
            projectModel.CreatedByUserId = 1;
            projectModel.Deleted = false;
            projectModel.Notes = "Stuff";
            projectModel.ProjectName = "Hello World";
            projectModel.ProjectNumber = "123123CD";
            
            ViewResult result = this.controller.Create(projectModel) as ViewResult;
            
        }
    }
}
