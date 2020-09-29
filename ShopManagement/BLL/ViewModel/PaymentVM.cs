using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.BLL.ViewModel
{
    public class PaymentVM
    {
        public long PaymentID { get; set; }
        public Nullable<long> PaymentType { get; set; }
        public Nullable<long> PaymentMethod { get; set; }
        public Nullable<long> OrderId { get; set; }
        public Nullable<decimal> TotalAmount { get; set; }
        public Nullable<decimal> PaidAmount { get; set; }
        public Nullable<bool> IsDue { get; set; }
        public Nullable<decimal> DueAmount { get; set; }
        public Nullable<decimal> ChangeAmount { get; set; }
        public string CardNo { get; set; }
    }
}
