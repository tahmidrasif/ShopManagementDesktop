using ShopManagement.BLL.Mapping;
using ShopManagement.BLL.ViewModel;
using ShopManagement.DAL.Model;
using ShopManagement.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.BLL
{
    public class ProductPurchaseBLL
    {
        private UnitOfWork _unitOfWork;

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

        public DataTable GetPODetailsByPOID(long poId)
        {
            _unitOfWork = new UnitOfWork();
            SqlParameter[] parameters = new SqlParameter[]
                       {
                            new SqlParameter("@POId", poId)
                       };
            return _unitOfWork.repoBaseSp.ExecuteReader("SP_PurchaseOrderDetails", CommandType.StoredProcedure, parameters);

        }

        public PurchaseOrderVM GetPurchaseOrderById(long? orderId)
        {
            _unitOfWork = new UnitOfWork();
            PurchaseOrderVM oPo = new PurchaseOrderVM();
            var pOrder = _unitOfWork.repoPurchaseOrder.GetById(orderId);
            if (pOrder != null)
            {
                Vendor vendor = _unitOfWork.repoVendor.GetById(pOrder.VendorID);
                oPo = MappingConfig.Mapper.Map<PurchaseOrder, PurchaseOrderVM>(pOrder);
                oPo.VendorName = vendor?.Name;
            }
            return oPo;

        }

        public List<PurchaseOrderVM> GetOrders(long orderStatus, DateTime fromDate, DateTime toDate, string orderCode, long venodrId)
        {
            _unitOfWork = new UnitOfWork();
            List<PurchaseOrderVM> oPo = new List<PurchaseOrderVM>();
            var poList = _unitOfWork.repoPurchaseOrder.GetBySearch(orderStatus, fromDate, toDate, orderCode, venodrId);
            if (poList.Count > 0)
            {
                oPo = MappingConfig.Mapper.Map<List<PurchaseOrder>, List<PurchaseOrderVM>>(poList);
            }
            return oPo;
        }
    }
}
