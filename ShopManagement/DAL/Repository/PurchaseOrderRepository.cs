using ShopManagement.DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.DAL.Repository
{
    public class PurchaseOrderRepository : BaseRepository
    {
        public PurchaseOrderRepository()
        {
           
        }

        public void Add(PurchaseOrder po)
        {
            try
            {
                db.PurchaseOrder.Add(po);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }


    }
}
