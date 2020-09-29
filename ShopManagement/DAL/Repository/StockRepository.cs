using ShopManagement.DAL.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.DAL.Repository
{
    public class StockRepository : BaseRepository
    {
         private ShopDBEntities db;
        // public StockRepository(ShopDBEntities context)
        //{
        //    db = context;
        //}
         public StockRepository(ShopDBEntities context)
            : base(context)
        {
            db = context;
        }
        public Stock GetByProductId(long productId) 
        {
            Stock objStock = new Stock();

            if (productId>0)
            {
                objStock = db.Stock.SingleOrDefault(x => x.ProductID == productId);
                return objStock;
            }

            return objStock;
        }

        public void Update(Stock oStock)
        {
            db.Entry(oStock).State = EntityState.Modified;
            //db.Stock.Attach(oStock);
            //db.Entry(oStock).Property(x => x.Quantity).IsModified = true;
            //db.SaveChanges();
        }

        public void UpdateByProductId(long prodId)
        {

        }
    }
}
