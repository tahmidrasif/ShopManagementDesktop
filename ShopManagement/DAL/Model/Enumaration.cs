//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ShopManagement.DAL.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class Enumaration
    {
        public long EnumID { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string TypeDecscription { get; set; }
        public string Remarks { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedOn { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public Nullable<int> EnumOrder { get; set; }
        public Nullable<int> EnumSteps { get; set; }
    }
}
