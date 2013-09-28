using AutoMapper;
using Domain.Interfaces;
using Domain.IServices;
using Domain.Models.ViewModels;
using Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Timesheet.Core;
using Timesheet.Core.Interfaces;

namespace Domain.Services
{
    public class ProjectVMService : IProjectService
    {
        private IRepository Repository;
        private IMembership Membership;

        public ProjectVMService(IRepository repo, IMembership membership)
        {
            this.Repository = repo;
            this.Membership = membership;
        }

        public ProjectViewModel GetNewProjectVM(int clientId)
        {
            //build
            ProjectViewModel projectVM = new ProjectViewModel();
            ProjectModel projectModel = new ProjectModel();
            projectModel.ClientId = clientId;
            projectModel.CreatedByUserId = this.Membership.UserId();

            //set model to view model
            projectVM.ProjectM = projectModel;

            //set drop down list
            projectVM.ClientSL = new SelectList(this.GetClientSLI(), "Value", "Text");

            //return!!
            return projectVM;
        }

        public bool SaveNewProject(ProjectModel projectModel)
        {
            Project project = this.MapToEntity(projectModel);

            this.Repository.Add(project);
            this.Repository.CommitAndDispose();
            return true;
        }

        private List<SelectListItem> GetClientSLI()
        {
            List<ClientProfile> listOfClientProfiles = this.Repository.Many<ClientProfile>(x => x.fk_company_location == this.Membership.CompanyLocationId())
                .Where(x => x.deleted_on == null).ToList();
            return listOfClientProfiles.Select(x => new SelectListItem()
            {
                Text = x.client_name,
                Value = x.id_client.ToString()
            }).ToList();
        }

        public List<ProjectModel> GetUsersProjects()
        {
            List<Project> projects = this.Repository.Many<Project>(x => x.ClientProfile.fk_company_location == this.Membership.CompanyLocationId())
                .Where(x => x.deleted_on == null).ToList();

            return projects.Select(x => new ProjectModel()
            {
                id = x.id_projects,
                ClientId = x.fk_client,
                Created = x.created_at,
                CreatedByUserId = x.fk_created_by,
                Deleted = x.deleted_on != null,
                Notes = x.Notes,
                ProjectName = x.ProjectName,
                ClientName = x.ClientProfile.client_name,
                ProjectNumber = x.ProjectNumber
            }).ToList();
        }

        public ProjectViewModel GetExistingProjectVM(int projectId)
        {
            //build model
            Project project = this.Repository.Single<Project>(x=>x.id_projects == projectId);
            Mapper.CreateMap<Project, ProjectModel>();

            ProjectModel projectModel = Mapper.Map<ProjectModel>(project);
            projectModel.ClientId = project.fk_client;
            projectModel.Created = project.created_at;
            projectModel.CreatedByUserId = project.fk_created_by;
            projectModel.Deleted = project.deleted_on != null;
            projectModel.id = project.id_projects;
            
            //set model to viewmodel
            ProjectViewModel projectVM = new ProjectViewModel();
            projectVM.ProjectM = projectModel;            
            projectVM.ClientSL = new SelectList(this.GetClientSLI(), "Value", "Text"); //set dropdownlist

            //return project view wmodel
            return projectVM;
        }

        public bool SaveProjectEdits(ProjectModel projectModel)
        {
            Project project = this.MapToEntity(projectModel);

            this.Repository.Modify(project);
            this.Repository.CommitAndDispose();

            return true;
        }

        private Project MapToEntity(ProjectModel projectM)
        {
            Mapper.CreateMap<ProjectModel, Project>();
            Project project = Mapper.Map<Project>(projectM);
            project.created_at = DateTime.Now;
            project.fk_client = projectM.ClientId;
            project.fk_created_by = projectM.CreatedByUserId;
            project.updated_at = DateTime.Now;
            project.id_projects = projectM.id;

            return project;
        }
        private ProjectModel MapToModel(Project project)
        {
            Mapper.CreateMap<Project, ProjectModel>();
            ProjectModel projectM = Mapper.Map<ProjectModel>(project);
            projectM.Created = DateTime.Now;
            projectM.ClientId = project.fk_client;
            projectM.CreatedByUserId = project.fk_created_by;

            return projectM;
        }
    }
}
