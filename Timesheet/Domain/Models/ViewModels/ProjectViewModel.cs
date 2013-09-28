using Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Timesheet.Core;

namespace Domain.Models.ViewModels
{
    public class ProjectViewModel
    {
        public ProjectModel ProjectM { get; set; }
        public SelectList ClientSL { get; set; }
        public IEnumerable<ClientProfile> ClientProfiles { get; set; }
    }
}
