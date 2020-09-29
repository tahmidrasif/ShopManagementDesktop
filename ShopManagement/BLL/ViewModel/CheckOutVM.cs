using ShopManagement.DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.BLL.ViewModel
{
    public class CheckOutVM
    {
        public Order Order { get; set; }
        public List<OrderDetails> OrderDetails { get; set; }
        public Payment Payment { get; set; }


    }
}
