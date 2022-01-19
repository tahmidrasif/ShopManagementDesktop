using ShopManagement.BLL.Response;
using ShopManagement.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.BLL
{
    public class EnumarationBLL
    {
        UnitOfWork oUnitOfWork;
        public EnumarationBLL()
        {
            oUnitOfWork = new UnitOfWork();
        }


        public List<EnumarationResponse> GetAllByType(string type)
        {
            var objEnumList = oUnitOfWork.repoEnum.GetAll(type);
            List<EnumarationResponse> objRespList = new List<EnumarationResponse>();
            if (objEnumList.Count>0)
            {
                
                foreach (var item in objEnumList)
                {
                    EnumarationResponse objEnumBLL = new EnumarationResponse()
                    {
                        EnumID = item.EnumID,
                        Name = item.Name,
                        Type = item.Type,
                        TypeDecscription = item.TypeDecscription,
                        Remarks = item.Remarks
                    };

                    objRespList.Add(objEnumBLL);
                }
            }

            return objRespList;
        }

        public List<EnumarationResponse> GetAllByTypeDescription(string typeDescription)
        {
            var objEnumList = oUnitOfWork.repoEnum.GetAllByTypeDescription(typeDescription);
            List<EnumarationResponse> objRespList = new List<EnumarationResponse>();
            if (objEnumList.Count > 0)
            {

                foreach (var item in objEnumList)
                {
                    EnumarationResponse objEnumBLL = new EnumarationResponse()
                    {
                        EnumID = item.EnumID,
                        Name = item.Name,
                        Type = item.Type,
                        TypeDecscription = item.TypeDecscription,
                        Remarks = item.Remarks
                    };

                    objRespList.Add(objEnumBLL);
                }
            }

            return objRespList;
        }
    }
}
