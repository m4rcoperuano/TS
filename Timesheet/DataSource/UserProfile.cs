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
    
    public partial class UserProfile
    {
        public UserProfile()
        {
            this.webpages_Roles = new HashSet<webpages_Roles>();
        }
    
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public System.DateTime created_on { get; set; }
        public System.DateTime updated_on { get; set; }
        public Nullable<System.DateTime> deleted_on { get; set; }
        public int fk_company_location { get; set; }
    
        public virtual CompanyLocation CompanyLocation { get; set; }
        public virtual ICollection<webpages_Roles> webpages_Roles { get; set; }
    }
}