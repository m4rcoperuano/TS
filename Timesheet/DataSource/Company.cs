//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Timesheet.Core
{
    using System;
    using System.Collections.Generic;
    
    public partial class Company
    {
        public Company()
        {
            this.CompanyLocations = new HashSet<CompanyLocation>();
        }
    
        public int id_company { get; set; }
        public string Name { get; set; }
        public Nullable<int> fk_logo { get; set; }
    
        public virtual FileStorage FileStorage { get; set; }
        public virtual ICollection<CompanyLocation> CompanyLocations { get; set; }
    }
}
