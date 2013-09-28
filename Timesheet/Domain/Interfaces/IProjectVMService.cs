using Domain.Models.ViewModels;
using Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IProjectService
    {
        ProjectViewModel GetNewProjectVM(int clientId);
        ProjectViewModel GetExistingProjectVM(int projectId);
        List<ProjectModel> GetUsersProjects();
        bool SaveNewProject(ProjectModel projectModel);
        bool SaveProjectEdits(ProjectModel projectModel);
    }
}
