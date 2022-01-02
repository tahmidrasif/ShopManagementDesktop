using ShopManagement.DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.DAL.Repository
{
    public class PaymentRepository:BaseRepository
    {
        //public PaymentRepository(ShopDBEntities context)
        //{
        //    db = context;
        //}
        public PaymentRepository()
        {

        }
        public void Add(Payment oPayment)
        {
            db.Payment.Add(oPayment);
        }
    }
}
