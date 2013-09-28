using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.ViewModels;
using System.Web.Mvc;
using Timesheet.Core;

namespace Domain.ViewModels
{
    public class ClientProfileViewModel
    {
        public IEnumerable<State> States { get; set; }
        public SelectList StatesSL { get; set; }        
        public ClientProfileModel ClientProfileM { get; set; }
    }
}
