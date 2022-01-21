using ShopManagement.BLL.Mapping;
using ShopManagement.BLL.ViewModel;
using ShopManagement.DAL.Model;
using ShopManagement.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.BLL
{
    public class ProductPurchaseBLL
    {
        private  UnitOfWork _unitOfWork;

        public ProductPurchaseBLL()
        {
            //_unitOfWork = new UnitOfWork();
        }

        public string PlaceOrder(PurchaseOrderVM purchaseOrderVm)
        {
            try
            {
                _unitOfWork = new UnitOfWork();
                if (purchaseOrderVm != null)
                {
                    //PurchaseOrder oPo = null;
                    //oPo.PurchaseOrderDetails = new List<PurchaseOrderDetails>();
                    //var map=MappingConfig.Mapper.Map(purchaseOrderVm, oPo);
                    PurchaseOrder oPo = MappingConfig.Mapper.Map<PurchaseOrderVM, PurchaseOrder>(purchaseOrderVm);
                    if (oPo == null)
                    {
                        return "Failed To Map";
                    }
                    _unitOfWork.BeginTrnsaction();
                    _unitOfWork.repoPurchaseOrder.Add(oPo);
                    _unitOfWork.Save();
                    _unitOfWork.CommitTransaction();
    
            }
                return "Success";
            }
            catch (Exception ex)
            {
                _unitOfWork.RollbackTransaction();
                return ex.Message;
            }
        }
    }
}
