using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.DAL.Model
{
    public class GlobalEnum
    {
        public enum TransactionType
        {
            PurchaseGoods,
            SaleGoods,
            PurchaseFurniture,
            SalaryPaid,
            PayRent
        }

        public enum PaymentType
        {
            Cash,
            Credit
        }

        public enum PaymentMethod
        {
            Cash,
            Card,
            Chque
        }
    }
}
