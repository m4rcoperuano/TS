using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ViewModels
{
    public class ProjectModel
    {
        public int id { get; set; }

        [Required]
        [Display(Name="Project Name")]
        public string ProjectName { get; set; }

        [Required]
        [Display(Name="Project #")]
        public string ProjectNumber { get; set; }

        public string Notes { get; set; }

        public DateTime Created { get; set; }
        public bool Deleted { get; set; }

        [Required]
        [Display(Name="Client")]
        public int ClientId { get; set; }
        public string ClientName { get; set; }

        public int CreatedByUserId { get; set; }
    }
}
