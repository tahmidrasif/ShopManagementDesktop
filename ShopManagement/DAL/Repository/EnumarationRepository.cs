using ShopManagement.DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.DAL.Repository
{
    public class EnumarationRepository : BaseRepository
    {
  
        // public EnumarationRepository(ShopDBEntities context)
        //{
        //    db = context;
        //}
         public EnumarationRepository()
        {

        }
        public List<Enumaration> GetAll(string type)
        {
            var enumaration= db.Enumaration.Where(x=>x.Type==type && x.IsActive==true).ToList();

            return enumaration;
        }
    }
}
