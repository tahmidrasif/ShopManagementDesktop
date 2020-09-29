using ShopManagement.DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.DAL.Repository
{
    public class BaseRepository
    {
        public ShopDBEntities db; 
        public BaseRepository(ShopDBEntities db)
        {
             db = new ShopDBEntities();
        }
    }
}
