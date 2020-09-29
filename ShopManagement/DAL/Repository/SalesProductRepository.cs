﻿using ShopManagement.DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.DAL.Repository
{
    public class SalesProductRepository : BaseRepository
    {
        private ShopDBEntities db;
        public SalesProductRepository(ShopDBEntities context)
            : base(context)
        {
            db = context;
        }
        public List<SalesProductViewModel> SearchSalesProduct(string productCode)
        {
            if (!string.IsNullOrEmpty(productCode))
            {

                List<SalesProductViewModel> lstSalesProductViewModel = new List<SalesProductViewModel>();
                var productLst = db.Product.Where(x => x.ProductCode == productCode);

                if (productLst.Count() > 0)
                {
                    foreach (var product in productLst)
                    {


                        var stock = db.Stock.FirstOrDefault(x => x.ProductID == product.ProductID);
                        var unit = db.Unit.FirstOrDefault(x => x.UnitID == product.UnitID);


                        if (stock == null || unit == null)
                        {
                            return lstSalesProductViewModel;
                        }
                        else
                        {
                            var unitList = db.Unit.Where(x => x.UnitType == product.UnitType).ToList();

                            SalesProductViewModel objSalesProdVm = new SalesProductViewModel()
                            {
                                ProductID = product.ProductID,
                                PruductName = product.Name,
                                ProductCode = product.ProductCode,
                                ProductUnit = unit,
                                ProductUnitType = unitList,
                                UnitSalesPrice = (long)product.UnitSalesPrice,
                                SPVatIncluded = (bool)product.SPVatIncluded,
                                SPVatPercent = (long)product.SPVatPercent,
                                SPVat = (long)product.SPVat,
                                SPOtherCharge = (long)product.SPOtherCharge,
                                TotalSalesPrice = (long)product.TotalSalesPrice,
                                AvaliableQty = (long)stock.Quantity
                            };

                            lstSalesProductViewModel.Add(objSalesProdVm);
                        }

                    }

                    return lstSalesProductViewModel;
                }

            }

            return new List<SalesProductViewModel>();

        }
    }
}
