using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.BLL.ViewModel
{
    public class CartVM
    {
        public long ProductID { get; set; }
        public string ProductName { get; set; }
        public string ProductCode { get; set; }
        public long UnitID { get; set; }
        public string Unit { get; set; }
        public decimal UnitSalesPrice { get; set; }
        public decimal Quantity { get; set; }
        public decimal SPVatPercent { get; set; }
        public decimal SPVat { get; set; }
        public decimal SPOtherCharge { get; set; }
        public decimal TotalSalesPrice { get; set; }
        public decimal SubTotal { get; set; }
        public decimal DiscountAmt { get; set; }
        public decimal DiscountPercent { get; set; }
    }
}
