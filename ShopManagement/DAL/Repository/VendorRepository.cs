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

        public VendorRepository()
        {

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
    }
}
