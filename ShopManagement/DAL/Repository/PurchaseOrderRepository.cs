using ShopManagement.DAL.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.DAL.Repository
{
    public class PurchaseOrderRepository : BaseRepository
    {
        private ShopDBEntities db;
        public PurchaseOrderRepository()
        {

        }
        public PurchaseOrderRepository(ShopDBEntities context)
        {
            db = context;
        }
        public void Add(PurchaseOrder po)
        {
            try
            {
                db.PurchaseOrder.Add(po);
                if (po.POrderID > 0)
                {
                    DeletePurchaseDetails(po.POrderID);
                    db.Entry(po).State = System.Data.Entity.EntityState.Modified;
                    
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        private void DeletePurchaseDetails(long pOrderID)
        {
            try
            {
                var poDetails=db.PurchaseOrderDetails.Where(x=>x.POrderID==pOrderID).AsQueryable();
                db.PurchaseOrderDetails.RemoveRange(poDetails);
               
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<PurchaseOrder> GetBySearch(long orderStatus, DateTime fromDate, DateTime toDate, string orderCode, long venodrId)
        {
            IQueryable<PurchaseOrder> poList = db.PurchaseOrder.AsQueryable();
            if (orderStatus > 0)
            {
                poList = poList.Where(x => x.Status == orderStatus);
            }
            if (fromDate <= toDate)
            {
                poList = poList.Where(x => x.OrderDate >= fromDate && x.OrderDate < toDate).AsQueryable();
            }
            if (!string.IsNullOrEmpty(orderCode))
            {
                poList = poList.Where(x => x.POrderCode.Contains(orderCode)).AsQueryable();
            }
            if (venodrId > 0)
            {
                poList = poList.Where(x => x.VendorID == venodrId).AsQueryable();
            }

            Console.WriteLine(poList.ToString());
            return poList.ToList();

        }

        public void Update(PurchaseOrder oPo)
        {
            try
            {
                db.PurchaseOrder.Add(oPo);
                db.Entry(oPo).State = System.Data.Entity.EntityState.Modified;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public PurchaseOrder GetById(long? orderId)
        {
            return db.PurchaseOrder.FirstOrDefault(x => x.POrderID == orderId);
        }
    }
}
