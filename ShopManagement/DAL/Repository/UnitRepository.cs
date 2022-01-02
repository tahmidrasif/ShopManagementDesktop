using ShopManagement.BLL.ViewModel;
using ShopManagement.DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.DAL.Repository
{
    public class UnitRepository:BaseRepository
    {
        // public UnitRepository(ShopDBEntities context)
        //{
        //    db = context;
        //}
         public UnitRepository()
        {

        }
        public Unit GetSingleById(long id)
        {
            Unit objUnit = new Unit();

            if (id>0)
            {
                objUnit = db.Unit.FirstOrDefault(x => x.UnitID==id);
                return objUnit;
            }

            return objUnit;
        }
        public List<Unit> GetByUnitType(string type)
        {
            List<Unit> objUnitList = new List<Unit>();

            if (!string.IsNullOrEmpty(type))
            {
                objUnitList = db.Unit.Where(x => x.UnitType == type).ToList();
                return objUnitList;
            }

            return objUnitList;
        }

        public List<Unit> GetAll()
        {
            return  db.Unit.Where(x=>x.IsActive==true).ToList();
        }
    }
}
