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
    
    public partial class FileStorage
    {
        public FileStorage()
        {
            this.Companies = new HashSet<Company>();
        }
    
        public int id_file { get; set; }
        public string FileName { get; set; }
        public int FileSize { get; set; }
        public string FilePath { get; set; }
        public string FileExtension { get; set; }
        public int fk_file_type { get; set; }
        public System.DateTime DateCreated { get; set; }
        public Nullable<System.DateTime> DateDeleted { get; set; }
    
        public virtual ICollection<Company> Companies { get; set; }
    }
}