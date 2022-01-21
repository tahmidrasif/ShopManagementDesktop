using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopManagement.BLL.ViewModel;
using ShopManagement.DAL.Model;
using ShopManagement.DAL.Repository;

namespace ShopManagement.BLL
{
    public class ProductBLL
    {
        private UnitOfWork _unitOfWork;
        public ProductBLL()
        {
            //_unitOfWork = new UnitOfWork();
        }
        public List<CategoryVM> GetAllCategory()
        {
            _unitOfWork = new UnitOfWork();
            List<CategoryVM> categoryVmList = new List<CategoryVM>();
            var categoryList = _unitOfWork.repoCategory.GetAllCategories();
            if (categoryList != null && categoryList.Count > 0)
            {
                foreach (var category in categoryList)
                {
                    CategoryVM categoryVm = new CategoryVM()
                    {
                        CategoryCode = category.CategoryCode,
                        CategoryID = category.CategoryID,
                        CategoryName = category.CategoryName,
                        CreatedBy = category.CreatedBy,
                        Description = category.Description,
                        CategoryFullName = category.CategoryName + "--" + category.CategoryCode
                        //CreatedOn = (DateTime) category.CreatedOn
                    };

                    categoryVmList.Add(categoryVm);
                }

            }

            return categoryVmList;
        }

        public List<ProductViewModel> GetAllProducts()
        {
            _unitOfWork = new UnitOfWork();
            List<ProductViewModel> productvmList = new List<ProductViewModel>();
            var productList = _unitOfWork.repoProduct.GetAll();
            if (productList.Count > 0)
                productvmList = MapProductsToViewModel(productList);
            return productvmList;
        }

        private List<ProductViewModel> MapProductsToViewModel(List<Product> products)
        {
            _unitOfWork = new UnitOfWork();
            List<ProductViewModel> productvmList = new List<ProductViewModel>();
            foreach (var product in products)
            {
                ProductViewModel obj = new ProductViewModel();
                obj.ProductCode = product.ProductCode;
                obj.ProductID = product.ProductID;
                obj.ProductName = product.Name;
                if (product.CategoryID != null)
                {
                    obj.CategoryID = (long)product.CategoryID;
                    obj.CategoryName = _unitOfWork.repoCategory.GetCategory(x => x.CategoryID == obj.CategoryID).CategoryName;
                    //var category = _unitOfWork.repoCategory.GetSingle(x => x.CategoryID == obj.CategoryID);
                }
                if (product.SubCategoryID != null)
                {
                    obj.SubCategoryID = (long)product.SubCategoryID;
                    obj.SubCategoryName = _unitOfWork.repoCategory.GetSubCategorySingle(x => x.SubCategoryID == obj.SubCategoryID).Name;
                }
                if (product.UnitID != null)
                {
                    obj.UnitID = (long)product.UnitID;
                    obj.UnitName = _unitOfWork.repoUnit.GetSingleById((long)product.UnitID).UnitName;
                }
                var productPrice = _unitOfWork.repoProduct.GetSingleProductPrice(product.ProductID);
                obj.UnitSalesPrice = (decimal)productPrice.UnitSalesPrice;
                obj.SPVat = (decimal)productPrice.SPVat;
                obj.SPOtherCharge = (decimal)productPrice.SPOtherCharge;
                obj.TotalSalesPrice = (decimal)productPrice.TotalSalesPrice;
                obj.UnitPurchasePrice = (decimal)productPrice.UnitPurchasePrice;
                obj.PPVat = (decimal)productPrice.PPVat;
                obj.PPOtherCharge = (decimal)productPrice.PPOtherCharge;
                obj.TotalPurchasePrice = (decimal)productPrice.TotalPurchasePrice;
                obj.AvaliableQty = (decimal)_unitOfWork.repoStock.GetByProductId(product.ProductID).Quantity;
                productvmList.Add(obj);
            }
            return productvmList;
        }

        public string InsertProduct(ProductViewModel productVM)
        {
            try
            {
                _unitOfWork = new UnitOfWork();
                Product objProduct = new Product();
                ProductPrice objProductPrice = new ProductPrice();
                Stock objStock = new Stock();

                if (productVM != null)
                {
                    if (IsProductAlreadyAvailable(productVM.ProductName, productVM.ProductCode))
                    {
                        return "Product is already available";
                    }

                    objProduct.ProductCode = productVM.ProductCode;
                    objProduct.Name = productVM.ProductName;
                    objProduct.IsActive = true;
                    objProduct.CategoryID = productVM.CategoryID;
                    objProduct.SubCategoryID = productVM.SubCategoryID;
                    objProduct.UnitID = productVM.UnitID;
                    objProduct.CreatedBy = "Tahmid";
                    objProduct.CreatedOn = DateTime.Now;

                    _unitOfWork.BeginTrnsaction();
                    _unitOfWork.repoProduct.Insert(objProduct);
                    _unitOfWork.Save();

                    objProductPrice.ProductID = objProduct.ProductID;
                    objProductPrice.UnitSalesPrice = productVM.UnitSalesPrice;
                    objProductPrice.SPVat = productVM.SPVat;
                    objProductPrice.SPOtherCharge = productVM.SPOtherCharge;
                    objProductPrice.SPDiscount = productVM.Discount;
                    objProductPrice.TotalSalesPrice = productVM.TotalSalesPrice;
                    objProductPrice.IsActive = true;
                    objProductPrice.CreatedBy = "Tahmid";
                    objProductPrice.CreatedOn = DateTime.Now;
                    _unitOfWork.repoProduct.InsertProductPrice(objProductPrice);
                    _unitOfWork.Save();

                    objStock.ProductID = objProduct.ProductID;
                    objStock.Quantity = 0;
                    objStock.CreatedBy = "Tahmid";
                    objStock.CreatedOn = DateTime.Now;
                    objStock.IsActive = true;

                    _unitOfWork.repoStock.Insert(objStock);
                    _unitOfWork.Save();

                    _unitOfWork.CommitTransaction();

                    return "Successfully Inserted the product";
                }
                return "Error in Inserting Product";
            }
            catch (Exception exception)
            {
                _unitOfWork.RollbackTransaction();
                return exception.Message;
            }

        }

       

        private bool IsProductAlreadyAvailable(string productName, string productCode)
        {
            _unitOfWork = new UnitOfWork();
            var productByName = _unitOfWork.repoProduct.GetSingleByProductName(productName);
            if (productByName != null)
            {
                return true;
            }
            var productByCode = _unitOfWork.repoProduct.GetSingleByProductCode(productCode);
            if (productByCode != null)
            {
                return true;
            }
            return false;
        }

        public ProductViewModel GetProductByProductID(long porductID)
        {
            try
            {
                _unitOfWork = new UnitOfWork();
                var product = _unitOfWork.repoProduct.GetProduct(porductID);
                ProductViewModel obj = new ProductViewModel();
                obj.ProductCode = product.ProductCode;
                obj.ProductID = product.ProductID;
                obj.ProductName = product.Name;
                if (product.CategoryID != null)
                {
                    obj.CategoryID = (long)product.CategoryID;
                    obj.CategoryName = _unitOfWork.repoCategory.GetCategory(x => x.CategoryID == obj.CategoryID).CategoryName;
                    //var category = _unitOfWork.repoCategory.GetSingle(x => x.CategoryID == obj.CategoryID);
                }
                if (product.SubCategoryID != null)
                {
                    obj.SubCategoryID = (long)product.SubCategoryID;
                    obj.SubCategoryName = _unitOfWork.repoCategory.GetSubCategorySingle(x => x.SubCategoryID == obj.SubCategoryID).Name;
                }
                if (product.UnitID != null)
                {
                    obj.UnitID = (long)product.UnitID;
                    obj.UnitName = _unitOfWork.repoUnit.GetSingleById((long)product.UnitID).UnitName;
                }
                var productPrice = _unitOfWork.repoProduct.GetSingleProductPrice(product.ProductID);
                obj.UnitSalesPrice = (decimal)productPrice.UnitSalesPrice;
                obj.SPVat = (decimal)productPrice.SPVat;
                obj.SPOtherCharge = (decimal)productPrice.SPOtherCharge;
                obj.TotalSalesPrice = (decimal)productPrice.TotalSalesPrice;
                obj.AvaliableQty = (decimal)_unitOfWork.repoStock.GetByProductId(product.ProductID).Quantity;
                return obj;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public string UpdateProduct(ProductViewModel productVM)
        {
            try
            {
                _unitOfWork = new UnitOfWork();
                Product objProduct = null;
                ProductPrice objProductPrice = null;
                Stock objStock = new Stock();

                if (productVM != null)
                {
                    if (productVM.ProductID == 0)
                    {
                        return "Error in updating product";
                    }

                    objProduct = _unitOfWork.repoProduct.GetProduct(productVM.ProductID);
                    if (objProduct == null)
                    {
                        return "Product Not Found";
                    }

                    objProduct.ProductCode = productVM.ProductCode;
                    objProduct.Name = productVM.ProductName;
                    objProduct.CategoryID = productVM.CategoryID;
                    objProduct.SubCategoryID = productVM.SubCategoryID;
                    objProduct.UnitID = productVM.UnitID;
                    objProduct.UpdatedBy = "Tahmid";
                    objProduct.UpdatedOn = DateTime.Now;

                    _unitOfWork.BeginTrnsaction();
                    _unitOfWork.repoProduct.Update(objProduct);
                    _unitOfWork.Save();

                    objProductPrice = _unitOfWork.repoProduct.GetSingleProductPrice(productVM.ProductID);
                    if (objProductPrice == null)
                    {
                        _unitOfWork.RollbackTransaction();
                        return "Error in updating product";
                    }
                    objProductPrice.UnitSalesPrice = productVM.UnitSalesPrice;
                    objProductPrice.SPVat = productVM.SPVat;
                    objProductPrice.SPOtherCharge = productVM.SPOtherCharge;
                    objProductPrice.SPDiscount = productVM.Discount;
                    objProductPrice.TotalSalesPrice = productVM.TotalSalesPrice;
                    objProductPrice.ModifiedBy = "Tahmid";
                    objProductPrice.ModifiedOn = DateTime.Now;
                    _unitOfWork.repoProduct.UpdateProductPrice(objProductPrice);
                    _unitOfWork.Save();



                    _unitOfWork.CommitTransaction();

                    return "Successfully Updated the product";
                }
                return "Error in Updating Product";
            }
            catch (Exception exception)
            {
                _unitOfWork.RollbackTransaction();
                return exception.Message;
            }
        }

        internal string Delete(long porductID)
        {
            try
            {
                _unitOfWork = new UnitOfWork();
                Product objProduct = null;
                ProductPrice objProductPrice = null;
                objProduct = _unitOfWork.repoProduct.GetProduct(porductID);
                if (objProduct == null)
                {
                    return "Product Not Found";
                }

                objProduct.IsActive = false;
                objProduct.UpdatedBy = "Tahmid";
                objProduct.UpdatedOn = DateTime.Now;

                _unitOfWork.BeginTrnsaction();
                _unitOfWork.repoProduct.Delete(objProduct);
                _unitOfWork.Save();
                _unitOfWork.CommitTransaction();
                return "Data Deleted Successfully";

            }
            catch (Exception ex)
            {
                _unitOfWork.RollbackTransaction();
                throw ex;
            }
        }

        public List<ProductViewModel> GetAllProductsByProductName(string productName)
        {
            List<ProductViewModel> ovm = new List<ProductViewModel>();
            if (!string.IsNullOrEmpty(productName))
            {
                _unitOfWork = new UnitOfWork();
                var products = _unitOfWork.repoProduct.GetListByProductName(productName);
                if (products.Count > 0)
                {
                    ovm = MapProductsToViewModel(products);
                }
            }
            return ovm;
        }
        internal List<ProductViewModel> GetAllProductsByProductCode(string productCode)
        {
            List<ProductViewModel> ovm = new List<ProductViewModel>();
            if (!string.IsNullOrEmpty(productCode))
            {
                _unitOfWork = new UnitOfWork();
                var products = _unitOfWork.repoProduct.GetAllByProductCode(productCode);
                if (products.Count > 0)
                {
                    ovm = MapProductsToViewModel(products);
                }
            }
            return ovm;
        }
    }
}
