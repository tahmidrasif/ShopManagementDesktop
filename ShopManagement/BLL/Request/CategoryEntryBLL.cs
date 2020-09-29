using ShopManagement.BLL.Response;
using ShopManagement.BLL.ViewModel;
using ShopManagement.DAL.Model;
using ShopManagement.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.BLL.Request
{
    public class CategoryEntryBLL
    {
        UnitOfWork oUnitOfWork;
        CategorySearchResponse response = new CategorySearchResponse();
        public CategoryEntryBLL()
        {
            oUnitOfWork = new UnitOfWork();
        }
        public CategorySearchResponse GetCategoryByProductNameOrCode(string txtSearch, string type)
        {
            List<Category> categories = new List<Category>();
            if (type == "Name")
            {
                categories = oUnitOfWork.repoCategory.GetCategoryByNameOrCode(x => x.CategoryName.Contains(txtSearch));
            }
            if (type == "Code")
            {
                categories = oUnitOfWork.repoCategory.GetCategoryByNameOrCode(x => x.CategoryCode.Contains(txtSearch));
            }
            if (categories.Count > 0)
            {
                List<CategoryVM> cvmList = new List<CategoryVM>();

                foreach (var item in categories)
                {
                    CategoryVM cvm = new CategoryVM();
                    cvm.CategoryName = item.CategoryName;
                    cvm.CategoryID = item.CategoryID;
                    cvm.CategoryCode = item.CategoryCode;
                    cvm.Description = item.Description;
                    cvmList.Add(cvm);
                }

                response = new CategorySearchResponse()
                {
                    ResponseCode = "000",
                    CategoryVM = cvmList
                };
            }
            return response;
        }
    }
}
