using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ViewModels
{
    public class UserModel
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
        public Boolean Deleted { get; set; }
        public DateTime? DeletedOn { get; set; }

        public string CompanyName { get; set; }
        public int CompanyId { get; set; }
        public int CompanyLocationId { get; set; }
    }
}
