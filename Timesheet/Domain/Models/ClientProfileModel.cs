using DataSource;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class ClientProfileModel
    {        
        [Required]
        [Display(Name="Client Name")]
        public string ClientName { get; set; }

        [Display(Name = "Address Line 1")]
        public string Address { get; set; }

        [Display(Name = "Address Line 2")]
        public string Address2 { get; set; }

        [Display(Name = "City")]
        public string City { get; set; }

        [Display(Name = "State")]
        public int StateId { get; set; }

        [Display(Name = "Zip")]
        public string Zip { get; set; }
        
        public string Zip4 { get; set; }

        [Display(Name = "Company")]
        public int CompanyLocationId { get; set; }
    }
}
