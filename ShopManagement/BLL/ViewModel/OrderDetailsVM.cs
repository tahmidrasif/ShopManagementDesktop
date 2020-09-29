using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.BLL.ViewModel
{
    public class OrderDetailsVM
    {
        public long DProductID { get; set; }
        public decimal DQuantity { get; set; }
        public long DUnitID { get; set; }
        public decimal DUnitPrice { get; set; }
        public decimal DTotalPrice { get; set; }
        public decimal DTotalDiscount { get; set; }
        public decimal DTotalVat { get; set; }
        public decimal DOtherCharge { get; set; }
        public decimal DSubTotal { get; set; }
    }
}
