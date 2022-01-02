using System.Data;
using System.Data.SqlClient;
using ShopManagement.BLL.Request;
using ShopManagement.BLL.Response;
using ShopManagement.BLL.ViewModel;
using ShopManagement.DAL.Model;
using ShopManagement.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace ShopManagement.BLL
{
    public class SalesProductBLL
    {
        UnitOfWork oUnitOfWork;
        private long errorProductId = 0;
        private string errorProductName = "";
        private int SalesStepCount = 0;
        //ProductRepository repoProduct;
        //StockRepository repoStock;
        //UnitRepository repoUnit;
        //PaymentRepository repoPayment;
        //OrderRepository repoOrder;


        List<CartVM> cartVMList;
        public SalesProductBLL()
        {
            //repoProduct = new ProductRepository();
            //repoStock = new StockRepository();
            //repoUnit = new UnitRepository();
            //repoPayment = new PaymentRepository();
            //repoOrder = new OrderRepository();
            cartVMList = new List<CartVM>();
            oUnitOfWork = new UnitOfWork();
        }


        public SalesProductSearchResponse SearchProducts(string productcode)
        {
            try
            {
                SalesProductSearchResponse objSalesProdSearch = new SalesProductSearchResponse();
                if (true)
                {
                    var results = oUnitOfWork.repoProduct.GetAllByProductCode(productcode);

                    if (results.Count == 0)
                    {
                        objSalesProdSearch.ResponseCode = "0";
                        objSalesProdSearch.ResponseMessage = "No Product Found";
                        objSalesProdSearch.ProductSearchVMList = null;

                        return objSalesProdSearch;
                    }
                    else
                    {
                        List<ProductSearchResultVM> lstprodSearchResultVm = new List<ProductSearchResultVM>();
                        foreach (var result in results)
                        {
                            var stock = GetStockByProductId(result.ProductID);
                            var productPrice = oUnitOfWork.repoProduct.GetSingleProductPrice(result.ProductID);

                            ProductSearchResultVM prodSearchResultVm = new ProductSearchResultVM();
                            prodSearchResultVm.ProductID = result.ProductID;
                            prodSearchResultVm.ProductCode = result.ProductCode;
                            prodSearchResultVm.ProductName = result.Name;
                            prodSearchResultVm.ProductUnit = GetUnitByProductId((long)result.UnitID);
                            prodSearchResultVm.UnitName = prodSearchResultVm.ProductUnit.UnitName;
                            prodSearchResultVm.ProductUnitType = GetUnitListByUnitType(result.UnitType);
                            prodSearchResultVm.UnitSalesPrice = (long)productPrice.UnitSalesPrice;
                            prodSearchResultVm.SPVatIncluded = (bool)productPrice.SPVatIncluded;
                            prodSearchResultVm.SPVatPercent = (long)productPrice.SPVatPercent;
                            prodSearchResultVm.SPVat = (long)productPrice.SPVat;
                            prodSearchResultVm.SPOtherCharge = (long)productPrice.SPOtherCharge;
                            prodSearchResultVm.TotalSalesPrice = (long)productPrice.TotalSalesPrice;
                            prodSearchResultVm.AvaliableQty = (long)stock.Quantity;

                            lstprodSearchResultVm.Add(prodSearchResultVm);



                        }

                        objSalesProdSearch.ResponseCode = "1";
                        objSalesProdSearch.ResponseMessage = "Data Found";
                        objSalesProdSearch.ProductSearchVMList = lstprodSearchResultVm;
                        return objSalesProdSearch;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private Stock GetStockByProductId(long id)
        {
            try
            {
                return oUnitOfWork.repoStock.GetByProductId((long)id);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public decimal GetStockCountByProductId(long id)
        {
            try
            {
                return  (decimal)oUnitOfWork.repoStock.GetByProductId(id)?.Quantity;
            }
            catch (Exception ex)
            {
                return 0;
            }

        }

        public Unit GetUnitByProductId(long id)
        {
            try
            {
                return oUnitOfWork.repoUnit.GetSingleById((long)id);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public List<Unit> GetUnitListByUnitType(string type)
        {
            try
            {
                return oUnitOfWork.repoUnit.GetByUnitType(type);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public List<ProductListVM> GetProductList(object prodList)
        {
            List<ProductSearchResultVM> productList = (List<ProductSearchResultVM>)prodList;
            List<ProductListVM> lst = new List<ProductListVM>();
            foreach (var item in productList)
            {
                lst.Add(new ProductListVM()
                {
                    ProductID = item.ProductID,
                    Name = item.ProductName,
                    ProductCode = item.ProductCode,
                    Unit = item.ProductUnit.UnitName,
                    UnitSalesPrice = item.UnitSalesPrice
                });


            }
            return lst;
        }



        public CartResponse AddToCart(CartRequest cartRequest)
        {

            CartResponse response = new CartResponse();

            cartVMList.Add(new CartVM()
            {
                ProductID = cartRequest.ProductID,
                ProductCode = cartRequest.ProductCode,
                ProductName = cartRequest.ProductName,
                Quantity = cartRequest.Quantity,

                UnitID = cartRequest.UnitID,
                Unit = cartRequest.Unit,
                UnitSalesPrice = cartRequest.UnitSalesPrice,
                TotalSalesPrice = cartRequest.TotalSalesPrice,
                SubTotal = cartRequest.SubTotal,

                SPVat = cartRequest.SPVat,
                SPVatPercent = cartRequest.SPVatPercent,
                SPOtherCharge = cartRequest.SPOtherCharge,
                DiscountAmt = cartRequest.DiscountAmt,
                DiscountPercent = cartRequest.DiscountPercent,
            });

            response.TotalPrice = cartVMList.Sum(x => x.TotalSalesPrice);
            response.TotalVat = cartVMList.Sum(x => x.SPVat);
            response.TotalOtherCharge = cartVMList.Sum(x => x.SPOtherCharge);
            response.TotalDiscount = cartVMList.Sum(x => x.DiscountAmt);
            response.GrandTotal = response.TotalPrice + response.TotalVat + response.TotalOtherCharge - response.TotalDiscount;
            response.CartList = cartVMList;
            return response;
        }

        public CartResponse RemoveCart(string productcode)
        {

            CartResponse response = new CartResponse();

            var cartProduct = cartVMList.FirstOrDefault(x => x.ProductCode == productcode);
            if (cartProduct != null)
            {
                cartVMList.RemoveAll(x => x.ProductCode == productcode);

                response.TotalPrice = cartVMList.Sum(x => x.TotalSalesPrice);
                response.TotalVat = cartVMList.Sum(x => x.SPVat);
                response.TotalOtherCharge = cartVMList.Sum(x => x.SPOtherCharge);
                response.TotalDiscount = cartVMList.Sum(x => x.DiscountAmt);
                response.GrandTotal = response.TotalPrice + response.TotalVat + response.TotalOtherCharge - response.TotalDiscount;
                response.CartList = cartVMList;
                return response;

            }
            return null;
        }

        public bool IsProductInCart(long prodId)
        {
            var prodInCart = cartVMList.FirstOrDefault(x => x.ProductID == prodId);
            if (prodInCart == null)
            {
                return false;
            }
            return true;
        }

        public PaymentResponse SellProduct(PaymentRequest pr)
        {
            Order oOrder = new Order();
            List<OrderDetails> oDetailsList = new List<OrderDetails>();
            Payment oPayment = new Payment();
            string createdBy = "Tahmid";
            DateTime createdOn = DateTime.Now;
            PaymentResponse oresp = new PaymentResponse();

            try
            {

                oOrder.SubTotal = pr.OSubTotal;
                oOrder.TotalVat = pr.OTotalVat;
                oOrder.OtherCharge = pr.OOtherCharge;
                oOrder.TotalDiscount = pr.OTotalDiscount;
                oOrder.GrandTotal = pr.OGrandTotal;

                oOrder.OrderCode = "SW-" + DateTime.Now.ToString("yyyyMMddhhmmssfff");
                oOrder.OrderType = "Shop-Purchase";
                oOrder.OrderDate = DateTime.Now;
                oOrder.DeliveryDate = DateTime.Now.ToString();
                oOrder.DeliverDue = 0;
                oOrder.BranchID = 1;
                oOrder.Status = 1;
                oOrder.CreatedBy = createdBy;
                oOrder.CreatedOn = createdOn;
                oOrder.IsActive = true;
                oOrder.DeliveryCharge = 0;



                //Payment Start
                oPayment.PaymentType = pr.PaymentType;
                oPayment.PaymentMethod = pr.PaymentMethod;
                oPayment.TotalAmount = pr.TotalAmount;
                oPayment.PaidAmount = pr.PaidAmount;
                oPayment.IsDue = pr.IsDue;
                oPayment.DueAmount = pr.DueAmount;
                oPayment.ChangeAmount = pr.ChangeAmount;
                oPayment.CrDr = "CR";
                oPayment.CreatedBy = createdBy;
                oPayment.CreatedOn = createdOn;
                oPayment.IsActive = true;
                //Payment Ends

                oUnitOfWork.BeginTrnsaction();
                oUnitOfWork.repoOrder.Add(oOrder);
                oUnitOfWork.Save();
                SalesStepCount++;
                //Order Details
                foreach (var item in pr.ODetails)
                {
                    long cartProdId = Convert.ToInt64(item.DProductID);
                    errorProductId = cartProdId;
                    var product = oUnitOfWork.repoProduct.GetProduct(cartProdId);
                    errorProductName = product.Name;
                    decimal cartProdQty = item.DQuantity;
                    decimal productStockQty = (decimal)GetStockCountByProductId(cartProdId);
                    if (productStockQty > cartProdQty)
                    {
                        OrderDetails oDetails = new OrderDetails();
                        oDetails.OrderID = oOrder.OrderID;
                        oDetails.ProductID = item.DProductID;
                        oDetails.Quantity = item.DQuantity;
                        oDetails.UnitID = item.DUnitID;
                        oDetails.UnitPrice = item.DUnitPrice;
                        oDetails.TotalPrice = item.DTotalPrice;
                        oDetails.TotalDiscount = item.DTotalDiscount;
                        oDetails.TotalVat = item.DTotalVat;
                        oDetails.OtherCharge = item.DOtherCharge;
                        oDetails.SubTotal = item.DSubTotal;
                        oDetails.OrderStatus = 1;
                        oDetails.CreatedBy = createdBy;
                        oDetails.CreatedOn = createdOn;
                        oDetails.IsActive = true;

                        oDetailsList.Add(oDetails);


                        var stock = oUnitOfWork.repoStock.GetByProductId(item.DProductID);
                        stock.Quantity -= item.DQuantity;
                        //stock.UpdatedBy = createdBy;
                        //stock.UpdatedOn = createdOn;
                        //oUnitOfWork.repoStock.Update(stock);
                        //oUnitOfWork.Save();

                        SqlParameter[] parameters = new SqlParameter[]
                        {
                            new SqlParameter("@ProductId", item.DProductID),
                            new SqlParameter("@Qty", item.DQuantity)
                        };
                        int count = oUnitOfWork.repoBaseSp.ExecuteNonQuery("SP_UpdateStock", CommandType.StoredProcedure,
                            parameters);
                    }

                    else
                    {
                        oUnitOfWork.RollbackTransaction();
                        oresp = new PaymentResponse()
                        {
                            ResponseCode = "999",
                            ResponseMessage = "Product is out of stock"
                        };
                        return oresp;
                    }

                }
                SalesStepCount++;
                //Order Details End

                oUnitOfWork.repoOrder.AddOrderDetails(oDetailsList);
                oUnitOfWork.Save();

                oPayment.OrderId = oOrder.OrderID;
                oUnitOfWork.repoPayment.Add(oPayment);
                oUnitOfWork.Save();

                SalesStepCount++;

                oUnitOfWork.CommitTransaction();

                oresp = new PaymentResponse()
                {
                    ResponseCode = "000",
                    ResponseMessage = "Payment Successful",
                    OrderNo = oOrder.OrderCode
                };
                return oresp;

            }
            //catch (SqlException ex)
            //{
            //    oUnitOfWork.RollbackTransaction();
            //    oresp = new PaymentResponse()
            //    {
            //        ResponseCode = "999",
            //        ResponseMessage = "Payment Error due to stock not available" + ex.Message
            //    };
            //    return oresp;
            //}
            catch (Exception ex)
            {
                oUnitOfWork.RollbackTransaction();
                if (SalesStepCount == 1)
                {
                    oresp = new PaymentResponse()
                    {
                        ResponseCode = "998",
                        ResponseMessage = "Payment Error due to insufficient stock. Product Name: " + errorProductName
                    };
                    return oresp;
                }
                else
                {

                    oresp = new PaymentResponse()
                    {
                        ResponseCode = "999",
                        ResponseMessage = "Payment Error due to " + ex.Message
                    };
                    return oresp;

                }
            }
        }
    }
}
