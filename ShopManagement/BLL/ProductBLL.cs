using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopManagement.BLL.ViewModel;
using ShopManagement.DAL.Repository;

namespace ShopManagement.BLL
{
    public class ProductBLL
    {
        private UnitOfWork _unitOfWork;
        public ProductBLL()
        {
            _unitOfWork=new UnitOfWork();
        }
        public List<CategoryVM> GetAllCategory()
        {
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
                        CategoryFullName = category.CategoryName+"--"+category.CategoryCode
                        //CreatedOn = (DateTime) category.CreatedOn
                    };

                    categoryVmList.Add(categoryVm);
                }
               
            }

            return categoryVmList; 
        }

        public List<ProductViewModel> GetAllProducts()
        {
            List<ProductViewModel> productvmList=new List<ProductViewModel>();
            var productList=_unitOfWork.repoProduct.GetAll();

            foreach (var product in productList)
            {
                ProductViewModel obj=new ProductViewModel();
                obj.ProductCode = product.ProductCode;
                obj.ProductID = product.ProductID;
                obj.ProductName = product.Name;
                if (product.CategoryID != null)
                {
                    obj.CategoryID = (long)product.CategoryID;
                    obj.CategoryName = _unitOfWork.repoCategory.GetCategory(x => x.CategoryID == obj.CategoryID).CategoryName;
                    //var category = _unitOfWork.repoCategory.GetSingle(x => x.CategoryID == obj.CategoryID);
                }
                if (product.UnitID != null)
                {
                    obj.UnitID = (long) product.UnitID;
                    obj.UnitName = _unitOfWork.repoUnit.GetSingleById((long)product.UnitID).UnitName;
                }

                productvmList.Add(obj);
            }

            return productvmList;
        }
    }
}
