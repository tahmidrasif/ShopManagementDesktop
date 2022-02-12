using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.BLL.ViewModel
{
    public class TransactionVM
    {
        public long TransactionID { get; set; }
        public string ReferenceNo { get; set; }
        public string TransactionType { get; set; }
        public string TransactionCode { get; set; }
        public DateTime TransactionDate { get; set; }
        public Nullable<long> PaymentType { get; set; }
        public Nullable<long> PaymentMethod { get; set; }
        public decimal Amount { get; set; }
        public string CrDr { get; set; }
        public string CardNo { get; set; }
        public string ChequeNo { get; set; }
        public Nullable<bool> IsChequeCleared { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedOn { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public string Status { get; set; }
        public string Narration { get; set; }
    }
}
