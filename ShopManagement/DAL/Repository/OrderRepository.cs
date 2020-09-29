using ShopManagement.DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.DAL.Repository
{
    public class OrderRepository:BaseRepository
    {
         private ShopDBEntities db;
        // public OrderRepository(ShopDBEntities context)
        //{
        //    db = context;
        //}
         public OrderRepository(ShopDBEntities context)
            : base(context)
        {
            db = context;
        }
        public void Add(Order oOrder)
        {
            db.Order.Add(oOrder);
        }

        public void AddOrderDetails(List<OrderDetails> oDetails)
        {
            db.OrderDetails.AddRange(oDetails);
        }
    }
}
