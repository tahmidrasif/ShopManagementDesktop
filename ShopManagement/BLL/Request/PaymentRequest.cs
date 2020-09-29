using ShopManagement.BLL.ViewModel;
using ShopManagement.DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.BLL.Request
{
    public class PaymentRequest
    {

        public decimal OSubTotal { get; set; }
        public decimal OTotalVat { get; set; }
        public decimal OOtherCharge { get; set; }
        public decimal OTotalDiscount { get; set; }
        public decimal OGrandTotal { get; set; }

        public List<OrderDetailsVM> ODetails { get; set; }
       
        public long PaymentType { get; set; }
        public long PaymentMethod { get; set; }
        public string CardNo { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal PaidAmount { get; set; }
        public bool IsDue { get; set; }
        public decimal DueAmount { get; set; }
        public decimal ChangeAmount { get; set; }

    }
}
