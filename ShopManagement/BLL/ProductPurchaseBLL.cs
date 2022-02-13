using ShopManagement.BLL.Mapping;
using ShopManagement.BLL.ViewModel;
using ShopManagement.DAL.Model;
using ShopManagement.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
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

        public string POSendToVendor(PurchaseOrderVM po, long paymentType)
        {
            try
            {
                _unitOfWork = new UnitOfWork();
                PurchaseOrder objPo = new PurchaseOrder();
                objPo = MappingConfig.Mapper.Map<PurchaseOrderVM, PurchaseOrder>(po);
                _unitOfWork.BeginTrnsaction();

                _unitOfWork.repoPurchaseOrder.Update(objPo);
                if (po.TotalAdvance > 0)
                {
                    Transactions tran = new Transactions();
                    TransactionsMapper tmapper = _unitOfWork.repoTransactions.GetByTransactionName("Purchase Order");
                    Enumaration oEnum = _unitOfWork.repoEnum.GetAllByTypeDescription("TransactionStatus").FirstOrDefault(x => x.Name == "Authorized");
                    if (tmapper == null)
                    {
                        _unitOfWork.RollbackTransaction();
                        return "Internal Error";
                    }
                    if (oEnum == null)
                    {
                        _unitOfWork.RollbackTransaction();
                        return "Internal Error";
                    }
                    tran.Amount = po.TotalAdvance;
                    tran.TransactionType = tmapper.TypeCode;
                    //tran.TransactionCode = tmapper.TypeCode;
                    tran.CrDr = tmapper.CrDr;
                    tran.ReferenceNo = po.ReferenceNo;
                    tran.TransactionDate = DateTime.Now;
                    tran.PaymentType = paymentType;
                    tran.PaymentMethod = 0;
                    tran.CreatedBy = "tahmid";
                    tran.CreatedOn = DateTime.Now;
                    tran.IsActive = true;
                    tran.Status = oEnum.Name;
                    tran.Narration = "Paid";
                    tran.TransactionCode = DateTime.UtcNow.ToString("yyyyMMddHHmmssfff", CultureInfo.InvariantCulture) + GetRandomThreeDigit();

                    _unitOfWork.repoTransactions.InsertTransaction(tran);

                }
                _unitOfWork.Save();
                _unitOfWork.CommitTransaction();

                return "Success";
            }
            catch (Exception ex)
            {
                _unitOfWork.RollbackTransaction();
                return ex.Message;
            }

        }

        private string GetRandomThreeDigit()
        {
            Random generator = new Random();
            String r = generator.Next(99999, 10000000).ToString("D3");
            return r;
        }
    }
}
