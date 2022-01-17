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
    
    public partial class PurchaseOrder
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PurchaseOrder()
        {
            this.PurchaseOrderDetails = new HashSet<PurchaseOrderDetails>();
        }
    
        public long POrderID { get; set; }
        public string POrderCode { get; set; }
        public string OrderType { get; set; }
        public Nullable<System.DateTime> OrderDate { get; set; }
        public Nullable<System.DateTime> DeliveryDate { get; set; }
        public Nullable<long> VendorID { get; set; }
        public Nullable<bool> IsMasterInventoryOrder { get; set; }
        public Nullable<long> BranchID { get; set; }
        public Nullable<long> Status { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedOn { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public Nullable<decimal> SubTotal { get; set; }
        public Nullable<bool> IsVatIncluded { get; set; }
        public Nullable<decimal> VatPercent { get; set; }
        public Nullable<decimal> TotalVat { get; set; }
        public Nullable<decimal> TotalOtherCharge { get; set; }
        public Nullable<decimal> TotalDeliveryCharge { get; set; }
        public Nullable<decimal> DiscountPercent { get; set; }
        public Nullable<decimal> TotalDiscount { get; set; }
        public Nullable<decimal> TotalAdvance { get; set; }
        public Nullable<decimal> TotalDue { get; set; }
        public Nullable<decimal> GrandTotal { get; set; }
        public Nullable<decimal> AdditionalDiscount { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PurchaseOrderDetails> PurchaseOrderDetails { get; set; }
    }
}