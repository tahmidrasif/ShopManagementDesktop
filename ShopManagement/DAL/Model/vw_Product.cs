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
    
    public partial class vw_Product
    {
        public long ProductID { get; set; }
        public string ProductName { get; set; }
        public string ProductCode { get; set; }
        public Nullable<long> UnitID { get; set; }
        public string UnitName { get; set; }
        public Nullable<long> CategoryID { get; set; }
        public string CategoryName { get; set; }
        public long SubCategoryID { get; set; }
        public string SubCategoryName { get; set; }
        public Nullable<decimal> SaleUnitPrice { get; set; }
        public Nullable<decimal> SaleVat { get; set; }
        public Nullable<decimal> SaleOtherCharge { get; set; }
        public Nullable<decimal> SaleTotalPrice { get; set; }
        public Nullable<decimal> SaleDiscount { get; set; }
        public Nullable<decimal> AvaliableQty { get; set; }
        public Nullable<bool> IsActive { get; set; }
    }
}