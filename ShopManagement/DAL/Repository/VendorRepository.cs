using ShopManagement.DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.DAL.Repository
{
    public class VendorRepository : BaseRepository
    {
        private ShopDBEntities db;
        public VendorRepository()
        {

        }
        public VendorRepository(ShopDBEntities context)
        {
            db = context;
        }
        public void Insert(Vendor vendor)
        {
            try
            {
                db.Vendor.Add(vendor);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public List<Vendor> GetAllVendors()
        {
            try
            {
                return db.Vendor.ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public Vendor GetById(long? vendorID)
        {
            try
            {
                return db.Vendor.FirstOrDefault(x=>x.VendorId==vendorID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
