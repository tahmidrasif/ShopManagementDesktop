using ShopManagement.BLL.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.BLL.Response
{
    public class CartResponse
    {
        public decimal TotalPrice { get; set; }
        public decimal TotalVat { get; set; }
        public decimal TotalDiscount { get; set; }
        public decimal TotalOtherCharge { get; set; }
        public decimal GrandTotal { get; set; }
        public List<CartVM> CartList { get; set; }

    }
}
