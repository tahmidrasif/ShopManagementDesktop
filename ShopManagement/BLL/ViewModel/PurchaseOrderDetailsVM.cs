using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.BLL.ViewModel
{
    public class PurchaseOrderDetailsVM
    {
        public long POrderDetailsID { get; set; }
        public Nullable<long> POrderID { get; set; }
        public Nullable<long> ProductID { get; set; }
        public Nullable<decimal> Quantity { get; set; }
        public Nullable<long> UnitID { get; set; }
        public Nullable<decimal> UnitPrice { get; set; }
        public Nullable<decimal> TotalUnitPrice { get; set; }
        public Nullable<long> DiscountType { get; set; }
        public Nullable<decimal> DiscountPercent { get; set; }
        public Nullable<decimal> TotalDiscount { get; set; }
        public Nullable<bool> IsVatIncluded { get; set; }
        public Nullable<decimal> VatPercent { get; set; }
        public Nullable<decimal> TotalVat { get; set; }
        public Nullable<decimal> OtherCharge { get; set; }
        public Nullable<decimal> SubTotal { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedOn { get; set; }
        public Nullable<bool> IsActive { get; set; }
    }
}
