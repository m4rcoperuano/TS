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
    
    public partial class State
    {
        public State()
        {
            this.ClientProfiles = new HashSet<ClientProfile>();
        }
    
        public int id_state { get; set; }
        public string state_name { get; set; }
        public string state_abbrev { get; set; }
    
        public virtual ICollection<ClientProfile> ClientProfiles { get; set; }
    }
}
