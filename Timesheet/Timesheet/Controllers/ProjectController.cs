using Domain.Interfaces;
using Domain.IServices;
using Domain.Models.ViewModels;
using Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Timesheet.Controllers
{
    public class ProjectController : Controller
    {
        private IProjectService ProjectModelService;

        public ProjectController(IProjectService pms)
        {
            this.ProjectModelService = pms;
        }

        public ActionResult Create(int clientId = 0) //clientId
        {
            ProjectViewModel projectVM = this.ProjectModelService.GetNewProjectVM(clientId);
            return View(projectVM);
        }

        [HttpPost]
        public ActionResult Create([Bind(Prefix="ProjectM")] ProjectModel projectModel)
        {
            this.ProjectModelService.SaveNewProject(projectModel);
            return RedirectToAction("Manage");
        }

        public ActionResult Edit(int id = 0)
        {
            ProjectViewModel projectVM = this.ProjectModelService.GetExistingProjectVM(id);
            return View(projectVM);
        }

        [HttpPost]
        public ActionResult Edit([Bind(Prefix = "ProjectM")] ProjectModel projectModel)
        {
            this.ProjectModelService.SaveProjectEdits(projectModel);
            return RedirectToAction("Manage");
        }

        public ActionResult Manage()
        {
            List<ProjectModel> usersProjects = this.ProjectModelService.GetUsersProjects();
            return View(usersProjects);
        }
    }
}
