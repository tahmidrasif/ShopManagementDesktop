using System;
using System.Collections.Generic;
using System.Data.Entity.Core;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopManagement.BLL.ViewModel;
using ShopManagement.DAL.Model;
using ShopManagement.DAL.Repository;

namespace ShopManagement.BLL
{
    public class UnitBLL
    {
        private UnitOfWork _unitOfWork;

        public UnitBLL()
        {
            //oUnitOfWork=new UnitOfWork();
        }
        public List<UnitVM> GetAllUnit()
        {
            List<UnitVM> lstunitvm=new List<UnitVM>();
            try
            {
                _unitOfWork = new UnitOfWork();
                var unitList= _unitOfWork.repoUnit.GetAll();
                foreach (var unit in unitList)
                {
                    UnitVM oUnitVm = new UnitVM()
                    {
                        UnitID = unit.UnitID,
                        UnitName = unit.UnitName,
                        UnitType = unit.UnitType
                    };
                    lstunitvm.Add(oUnitVm);
                }
                return lstunitvm;

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
