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
    
    public partial class SubCategory
    {
        public long SubCategoryID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Nullable<long> CategoryID { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedOn { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public string SubCategoryCode { get; set; }
    }
}