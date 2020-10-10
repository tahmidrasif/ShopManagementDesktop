using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.BLL.ViewModel
{
    public class ProductViewModel
    {
        public long ProductID { get; set; }
        public string ProductName { get; set; }
        public string ProductCode { get; set; }
        public long UnitID { get; set; }
        public string UnitName { get; set; }
        public decimal UnitSalesPrice { get; set; }
        public long CategoryID { get; set; }
        public string CategoryName { get; set; }
        public long SubCategoryID { get; set; }
        public string SubCategoryName { get; set; }
        public decimal SPVat { get; set; }
        public decimal SPOtherCharge { get; set; }
        public decimal TotalSalesPrice { get; set; }
        public decimal AvaliableQty { get; set; }
        public decimal Discount { get; set; }
    }
}
