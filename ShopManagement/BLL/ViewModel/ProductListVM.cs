using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.BLL.ViewModel
{
    public class ProductListVM
    {
        public long ProductID { get; set; }
        public string Name { get; set; }
        public string ProductCode { get; set; }
        public string Unit { get; set; }
        public decimal UnitSalesPrice { get; set; }
    }
}
