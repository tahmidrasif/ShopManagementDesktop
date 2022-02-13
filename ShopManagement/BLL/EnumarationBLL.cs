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
        private UnitOfWork _unitOfWork;
        public EnumarationBLL()
        {
            //oUnitOfWork = new UnitOfWork();
        }


        public List<EnumarationResponse> GetAllByType(string type)
        {
            _unitOfWork = new UnitOfWork();
            var objEnumList = _unitOfWork.repoEnum.GetAll(type);
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

        public List<EnumarationResponse> GetAllByTypeDescription(string typeDescription)
        {
            _unitOfWork = new UnitOfWork();
            var objEnumList = _unitOfWork.repoEnum.GetAllByTypeDescription(typeDescription);
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

        public EnumarationResponse GetSingleByName(string name)
        {
            _unitOfWork = new UnitOfWork();
            var objEnum = _unitOfWork.repoEnum.GetSingleByName(name);
            EnumarationResponse objRespList = null;
            if (objEnum != null)
            {

                EnumarationResponse objEnumBLL = new EnumarationResponse()
                {
                    EnumID = objEnum.EnumID,
                    Name = objEnum.Name,
                    Type = objEnum.Type,
                    TypeDecscription = objEnum.TypeDecscription,
                    Remarks = objEnum.Remarks
                };
            }
            return objRespList;
        }

        public EnumarationResponse GetById(long? status)
        {
            _unitOfWork = new UnitOfWork();
            EnumarationResponse objEnumBLL = null;
            var objEnum = _unitOfWork.repoEnum.GetById(status);
            if (objEnum != null)
            {
                objEnumBLL = new EnumarationResponse()
                {
                    EnumID = objEnum.EnumID,
                    Name = objEnum.Name,
                    Type = objEnum.Type,
                    TypeDecscription = objEnum.TypeDecscription,
                    Remarks = objEnum.Remarks
                };
            }
            return objEnumBLL;
        }
    }
}
