//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataSource
{
    using System;
    using System.Collections.Generic;
    
    public partial class CompanyLocation
    {
        public CompanyLocation()
        {
            this.UserProfiles = new HashSet<UserProfile>();
            this.ClientProfiles = new HashSet<ClientProfile>();
        }
    
        public int id_company_locations { get; set; }
        public string CompanyLocation1 { get; set; }
        public int fk_company { get; set; }
    
        public virtual ICollection<UserProfile> UserProfiles { get; set; }
        public virtual Company Company { get; set; }
        public virtual ICollection<ClientProfile> ClientProfiles { get; set; }
    }
}
