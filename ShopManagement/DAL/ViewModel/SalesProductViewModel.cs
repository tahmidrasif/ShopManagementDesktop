using ShopManagement.DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.DAL
{
    public class SalesProductViewModel
    {
        public long ProductID { get; set; }
        public string PruductName { get; set; }
        public Unit ProductUnit { get; set; }
        public List<Unit> ProductUnitType { get; set; }

        public string ProductCode { get; set; }
        public decimal UnitSalesPrice { get; set; }
        public bool SPVatIncluded { get; set; }
        public decimal SPVatPercent { get; set; }
        public decimal SPVat { get; set; }
        public decimal SPOtherCharge { get; set; }
        public decimal TotalSalesPrice { get; set; }
        public decimal AvaliableQty { get; set; }
        public string ImagePath { get; set; }
        public string DiscountType { get; set; }
        public decimal DiscountAmt { get; set; }
        public decimal DiscountPercent { get; set; }
        public List<Product> FreeProducts { get; set; }
    }
}
