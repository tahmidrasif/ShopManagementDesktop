using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopManagement.DAL.Model;

namespace ShopManagement.DAL.ViewModel
{
    public class PaymentVM
    {
        public Order Order { get; set; }
        public List<OrderDetails> OrderDetails { get; set; }
        public Payment Payment { get; set; }

    }
}
