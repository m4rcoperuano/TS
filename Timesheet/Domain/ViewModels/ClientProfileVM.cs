using DataSource;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;
using System.Web.Mvc;

namespace Domain.ViewModels
{
    public class ClientProfileVM
    {
        public IEnumerable<State> States { get; set; }
        public SelectList StatesSL { get; set; }        
        public ClientProfileModel ClientProfileM { get; set; }
    }
}
