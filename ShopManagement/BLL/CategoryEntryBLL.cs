using System.Security.Cryptography.X509Certificates;
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
        private CategorySearchResponse response;
        private SubCatSearchResponse subcatresponse;
        private CrudResponse crudResponse;
        public CategoryEntryBLL()
        {
            oUnitOfWork = new UnitOfWork();
            response = new CategorySearchResponse();
        }

        public CategorySearchResponse GetAllCategory()
        {
            List<CategoryVM> cvmList = new List<CategoryVM>();
            var categories = oUnitOfWork.repoCategory.GetAllCategories();
            if (categories != null)
            {
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
                return response;
            }

            response = new CategorySearchResponse()
            {
                ResponseCode = "400",
                CategoryVM = null
            };

            return response;
        }

        public CategorySearchResponse GetCategoryByProductNameOrCode(string txtSearch, string type)
        {
            List<Category> categories = new List<Category>();
            if (!string.IsNullOrEmpty(txtSearch))
            {
                if (type == "Name")
                {
                    categories =
                        oUnitOfWork.repoCategory.GetCategoryByNameOrCode(x => x.CategoryName.Contains(txtSearch));
                }
                if (type == "Code")
                {
                    categories =
                        oUnitOfWork.repoCategory.GetCategoryByNameOrCode(x => x.CategoryCode == txtSearch);
                }
            }
            //else
            //{
            //    categories = oUnitOfWork.repoCategory.GetCategoryByNameOrCode(null);
            //}
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
                return response;
            }
            else
            {
                response.ResponseCode = null;
                response.CategoryVM = new List<CategoryVM>();
                return response;
            }

        }

        public bool IsCatCodeExist(string categoryCode)
        {
            Category cat = oUnitOfWork.repoCategory.GetCategory(x => x.CategoryCode == categoryCode);
            if (cat == null)
                return false;
            return true;
        }

        public bool IsCatNameExist(string categoryCode)
        {
            Category cat = oUnitOfWork.repoCategory.GetCategory(x => x.CategoryName == categoryCode);
            if (cat == null)
                return false;
            return true;
        }

        public void InsertCategory(CategoryEntryRequest oCategoryEntryRequest)
        {
            try
            {
                Category oCategory = new Category()
                {
                    CategoryName = oCategoryEntryRequest.CategoryName,
                    CategoryCode = oCategoryEntryRequest.CategoryCode,
                    Description = oCategoryEntryRequest.Description,
                    CreatedBy = oCategoryEntryRequest.UserName,
                    CreatedOn = DateTime.Now,
                    IsActive = true
                };
                oUnitOfWork.BeginTrnsaction();
                oUnitOfWork.repoCategory.Add(oCategory);
                oUnitOfWork.Save();
                oUnitOfWork.CommitTransaction();
            }
            catch (Exception ex)
            {
                oUnitOfWork.RollbackTransaction();
                throw ex;
            }

        }

        public CategoryVM GetCategoryByID(long CategoryId)
        {

            try
            {
                var cat = oUnitOfWork.repoCategory.GetCategory(x => x.CategoryID == CategoryId);
                CategoryVM oVm = new CategoryVM()
                {
                    CategoryID = cat.CategoryID,
                    CategoryCode = cat.CategoryCode,
                    CategoryName = cat.CategoryName,
                    Description = cat.Description
                };
                return oVm;
            }
            catch (Exception exception)
            {

                throw exception;
            }
        }

        public CrudResponse UpdateCategory(long CategoryId, CategoryUpdateRequest oCatUpd)
        {
            try
            {
                Category objCat = oUnitOfWork.repoCategory.GetCategory(x => x.CategoryID == CategoryId);
                if (objCat == null)
                {
                    crudResponse = new CrudResponse()
                    {
                        ResponseCode = "400",
                        ResponseMessage = "Not Found"
                    };
                    return crudResponse;
                }
                objCat.CategoryName = oCatUpd.CategoryName;
                objCat.Description = oCatUpd.Description;
                objCat.UpdatedBy = oCatUpd.UserName;
                objCat.UpdatedOn = DateTime.Now;

                oUnitOfWork.BeginTrnsaction();
                oUnitOfWork.repoCategory.Update(objCat);
                oUnitOfWork.Save();
                oUnitOfWork.CommitTransaction();

                crudResponse = new CrudResponse()
                {
                    ResponseCode = "200",
                    ResponseMessage = "Successfully Updated"
                };
                return crudResponse;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public CrudResponse DeleteCategory(long CategoryId)
        {
            try
            {
                Category objCat = oUnitOfWork.repoCategory.GetCategory(x => x.CategoryID == CategoryId);
                if (objCat == null)
                {
                    crudResponse = new CrudResponse()
                    {
                        ResponseCode = "400",
                        ResponseMessage = "Not Found"
                    };
                    return crudResponse;
                }
                oUnitOfWork.BeginTrnsaction();
                oUnitOfWork.repoCategory.Delete(CategoryId, objCat);
                oUnitOfWork.Save();
                oUnitOfWork.CommitTransaction();

                crudResponse = new CrudResponse()
                {
                    ResponseCode = "200",
                    ResponseMessage = "Successfully Deleted"
                };
                return crudResponse;
            }
            catch (Exception ex)
            {
                oUnitOfWork.RollbackTransaction();
                throw ex;
            }
        }

        public SubCatSearchResponse GetSubCategory(string txtSearch, string type)
        {
            List<SubCategory> subCategories = new List<SubCategory>();
            subcatresponse = new SubCatSearchResponse();
            if (!string.IsNullOrEmpty(txtSearch))
            {
                if (type == "Name")
                {
                    subCategories =
                        oUnitOfWork.repoCategory.GetSubCategory(x => x.Name.Contains(txtSearch));
                }
                if (type == "Code")
                {
                    subCategories =
                        oUnitOfWork.repoCategory.GetSubCategory(x => x.SubCategoryCode == txtSearch);
                }
            }
          
            if (subCategories.Count > 0)
            {
                List<SubCatVM> cvmList = new List<SubCatVM>();

                foreach (var item in subCategories)
                {
                    SubCatVM cvm = new SubCatVM();
                    cvm.Name = item.Name;
                    cvm.SubCategoryID = item.SubCategoryID;
                    cvm.SubCategoryCode = item.SubCategoryCode;
                    cvm.Description = item.Description;
                    cvm.CategoryID = (long)item.CategoryID;
                    cvm.CategoryName =
                        oUnitOfWork.repoCategory.GetCategory(x => x.CategoryID == item.CategoryID).CategoryName;
                    cvmList.Add(cvm);
                }

                subcatresponse.ResponseCode = "000";
                subcatresponse.SubCategoryVM = cvmList;

                return subcatresponse;
            }
            else
            {
                subcatresponse.ResponseCode = null;
                subcatresponse.SubCategoryVM = new List<SubCatVM>();
                return subcatresponse;
            }
        }

        public SubCatSearchResponse GetAllSubCategory()
        {
            List<SubCategory> subCategories = new List<SubCategory>();
            subcatresponse = new SubCatSearchResponse();



            subCategories = oUnitOfWork.repoCategory.GetSubCategory(null);

            if (subCategories.Count > 0)
            {
                List<SubCatVM> cvmList = new List<SubCatVM>();

                foreach (var item in subCategories)
                {
                    SubCatVM cvm = new SubCatVM();
                    cvm.Name = item.Name;
                    cvm.SubCategoryID = item.SubCategoryID;
                    cvm.SubCategoryCode = item.SubCategoryCode;
                    cvm.Description = item.Description;
                    cvm.CategoryID = (long)item.CategoryID;
                    cvm.CategoryName =
                        oUnitOfWork.repoCategory.GetCategory(x => x.CategoryID == item.CategoryID).CategoryName;
                    cvmList.Add(cvm);
                }

                subcatresponse.ResponseCode = "000";
                subcatresponse.SubCategoryVM = cvmList;

                return subcatresponse;
            }
            else
            {
                subcatresponse.ResponseCode = null;
                subcatresponse.SubCategoryVM = new List<SubCatVM>();
                return subcatresponse;
            }
        }


        public SubCatSearchResponse GetAllSubCategoryByCategoryId(long categoryId)
        {
            List<SubCategory> subCategories = new List<SubCategory>();
            subcatresponse = new SubCatSearchResponse();



            subCategories = oUnitOfWork.repoCategory.GetSubCategory(x => x.CategoryID == categoryId);

            if (subCategories.Count > 0)
            {
                List<SubCatVM> cvmList = new List<SubCatVM>();

                foreach (var item in subCategories)
                {
                    SubCatVM cvm = new SubCatVM();
                    cvm.Name = item.Name;
                    cvm.SubCategoryID = item.SubCategoryID;
                    cvm.SubCategoryCode = item.SubCategoryCode;
                    cvm.Description = item.Description;
                    cvm.CategoryID = (long)item.CategoryID;
                    cvm.CategoryName =
                        oUnitOfWork.repoCategory.GetCategory(x => x.CategoryID == item.CategoryID).CategoryName;
                    cvmList.Add(cvm);
                }

                subcatresponse.ResponseCode = "000";
                subcatresponse.SubCategoryVM = cvmList;

                return subcatresponse;
            }
            else
            {
                subcatresponse.ResponseCode = null;
                subcatresponse.SubCategoryVM = new List<SubCatVM>();
                return subcatresponse;
            }
        }

        public CrudResponse InsertSubCategory(SubCatEntryRequest osubcatentryReq)
        {
            try
            {
                SubCategory oCategory = new SubCategory()
                {
                    Name = osubcatentryReq.Name,
                    SubCategoryCode = osubcatentryReq.SubCategoryCode,
                    Description = osubcatentryReq.Description,
                    CategoryID = osubcatentryReq.CategoryID,
                    CreatedBy = osubcatentryReq.UserName,
                    CreatedOn = DateTime.Now,
                    IsActive = true
                };
                oUnitOfWork.BeginTrnsaction();
                oUnitOfWork.repoCategory.AddSubCategory(oCategory);
                oUnitOfWork.Save();
                oUnitOfWork.CommitTransaction();

                crudResponse = new CrudResponse()
                {
                    ResponseCode = "200",
                    ResponseMessage = "Successfully Saved"
                };
                return crudResponse;
            }
            catch (Exception ex)
            {
                oUnitOfWork.RollbackTransaction();
                throw ex;
            }
        }

        public CrudResponse UpdateSubCategory(long SubCategoryId, SubCatUpdateRequest oSubCatUpdateRequest)
        {
            try
            {
                SubCategory objSubCat = oUnitOfWork.repoCategory.GetSubCategorySingle(x => x.SubCategoryID == SubCategoryId);
                if (objSubCat == null)
                {
                    crudResponse = new CrudResponse()
                    {
                        ResponseCode = "400",
                        ResponseMessage = "Not Found"
                    };
                    return crudResponse;
                }
                objSubCat.Name = oSubCatUpdateRequest.Name;
                objSubCat.Description = oSubCatUpdateRequest.Description;
                objSubCat.CategoryID = oSubCatUpdateRequest.CategoryID;
                objSubCat.UpdatedBy = oSubCatUpdateRequest.UserName;
                objSubCat.UpdatedOn = DateTime.Now;

                oUnitOfWork.BeginTrnsaction();
                oUnitOfWork.repoCategory.UpdateSubCategory(objSubCat);
                oUnitOfWork.Save();
                oUnitOfWork.CommitTransaction();

                crudResponse = new CrudResponse()
                {
                    ResponseCode = "200",
                    ResponseMessage = "Successfully Updated"
                };
                return crudResponse;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public CrudResponse DeleteSubCategory(long SubCategoryId)
        {
            try
            {
                SubCategory objCat = oUnitOfWork.repoCategory.GetSubCategorySingle(x => x.SubCategoryID == SubCategoryId);
                if (objCat == null)
                {
                    crudResponse = new CrudResponse()
                    {
                        ResponseCode = "400",
                        ResponseMessage = "Not Found"
                    };
                    return crudResponse;
                }
                oUnitOfWork.BeginTrnsaction();
                oUnitOfWork.repoCategory.DeleteSubCategory(SubCategoryId, objCat);
                oUnitOfWork.Save();
                oUnitOfWork.CommitTransaction();

                crudResponse = new CrudResponse()
                {
                    ResponseCode = "200",
                    ResponseMessage = "Successfully Deleted"
                };
                return crudResponse;
            }
            catch (Exception ex)
            {
                oUnitOfWork.RollbackTransaction();
                throw ex;
            }
        }
    }
}
