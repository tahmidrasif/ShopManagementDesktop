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
        private UnitOfWork _unitOfWork;
        private CategorySearchResponse response;
        private SubCatSearchResponse subcatresponse;
        private CrudResponse crudResponse;
        public CategoryEntryBLL()
        {
            
            response = new CategorySearchResponse();
        }

        public CategorySearchResponse GetAllCategory()
        {
            _unitOfWork = new UnitOfWork();
            List<CategoryVM> cvmList = new List<CategoryVM>();
            var categories = _unitOfWork.repoCategory.GetAllCategories();
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
            _unitOfWork = new UnitOfWork();
            List<Category> categories = new List<Category>();
            if (!string.IsNullOrEmpty(txtSearch))
            {
                if (type == "Name")
                {
                    categories =
                        _unitOfWork.repoCategory.GetCategoryByNameOrCode(x => x.CategoryName.Contains(txtSearch));
                }
                if (type == "Code")
                {
                    categories =
                        _unitOfWork.repoCategory.GetCategoryByNameOrCode(x => x.CategoryCode == txtSearch);
                }
            }
            //else
            //{
            //    categories = _unitOfWork.repoCategory.GetCategoryByNameOrCode(null);
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
            _unitOfWork = new UnitOfWork();
            Category cat = _unitOfWork.repoCategory.GetCategory(x => x.CategoryCode == categoryCode);
            if (cat == null)
                return false;
            return true;
        }

        public bool IsCatNameExist(string categoryCode)
        {
            _unitOfWork = new UnitOfWork();
            Category cat = _unitOfWork.repoCategory.GetCategory(x => x.CategoryName == categoryCode);
            if (cat == null)
                return false;
            return true;
        }

        public void InsertCategory(CategoryEntryRequest oCategoryEntryRequest)
        {
            _unitOfWork = new UnitOfWork();
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
                _unitOfWork.BeginTrnsaction();
                _unitOfWork.repoCategory.Add(oCategory);
                _unitOfWork.Save();
                _unitOfWork.CommitTransaction();
            }
            catch (Exception ex)
            {
                _unitOfWork.RollbackTransaction();
                throw ex;
            }

        }

        public CategoryVM GetCategoryByID(long CategoryId)
        {
            _unitOfWork = new UnitOfWork();

            try
            {
                var cat = _unitOfWork.repoCategory.GetCategory(x => x.CategoryID == CategoryId);
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
            _unitOfWork = new UnitOfWork();
            try
            {
                Category objCat = _unitOfWork.repoCategory.GetCategory(x => x.CategoryID == CategoryId);
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

                _unitOfWork.BeginTrnsaction();
                _unitOfWork.repoCategory.Update(objCat);
                _unitOfWork.Save();
                _unitOfWork.CommitTransaction();

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
            _unitOfWork = new UnitOfWork();
            try
            {
                Category objCat = _unitOfWork.repoCategory.GetCategory(x => x.CategoryID == CategoryId);
                if (objCat == null)
                {
                    crudResponse = new CrudResponse()
                    {
                        ResponseCode = "400",
                        ResponseMessage = "Not Found"
                    };
                    return crudResponse;
                }
                _unitOfWork.BeginTrnsaction();
                _unitOfWork.repoCategory.Delete(CategoryId, objCat);
                _unitOfWork.Save();
                _unitOfWork.CommitTransaction();

                crudResponse = new CrudResponse()
                {
                    ResponseCode = "200",
                    ResponseMessage = "Successfully Deleted"
                };
                return crudResponse;
            }
            catch (Exception ex)
            {
                _unitOfWork.RollbackTransaction();
                throw ex;
            }
        }

        public SubCatSearchResponse GetSubCategory(string txtSearch, string type)
        {
            _unitOfWork = new UnitOfWork();
            List<SubCategory> subCategories = new List<SubCategory>();
            subcatresponse = new SubCatSearchResponse();
            if (!string.IsNullOrEmpty(txtSearch))
            {
                if (type == "Name")
                {
                    subCategories =
                        _unitOfWork.repoCategory.GetSubCategory(x => x.Name.Contains(txtSearch));
                }
                if (type == "Code")
                {
                    subCategories =
                        _unitOfWork.repoCategory.GetSubCategory(x => x.SubCategoryCode == txtSearch);
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
                        _unitOfWork.repoCategory.GetCategory(x => x.CategoryID == item.CategoryID).CategoryName;
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
            _unitOfWork = new UnitOfWork();
            List<SubCategory> subCategories = new List<SubCategory>();
            subcatresponse = new SubCatSearchResponse();



            subCategories = _unitOfWork.repoCategory.GetSubCategory(null);

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
                        _unitOfWork.repoCategory.GetCategory(x => x.CategoryID == item.CategoryID).CategoryName;
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
            _unitOfWork = new UnitOfWork();
            List<SubCategory> subCategories = new List<SubCategory>();
            subcatresponse = new SubCatSearchResponse();



            subCategories = _unitOfWork.repoCategory.GetSubCategory(x => x.CategoryID == categoryId);

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
                        _unitOfWork.repoCategory.GetCategory(x => x.CategoryID == item.CategoryID).CategoryName;
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
            _unitOfWork = new UnitOfWork();
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
                _unitOfWork.BeginTrnsaction();
                _unitOfWork.repoCategory.AddSubCategory(oCategory);
                _unitOfWork.Save();
                _unitOfWork.CommitTransaction();

                crudResponse = new CrudResponse()
                {
                    ResponseCode = "200",
                    ResponseMessage = "Successfully Saved"
                };
                return crudResponse;
            }
            catch (Exception ex)
            {
                _unitOfWork.RollbackTransaction();
                throw ex;
            }
        }

        public CrudResponse UpdateSubCategory(long SubCategoryId, SubCatUpdateRequest oSubCatUpdateRequest)
        {
            _unitOfWork = new UnitOfWork();
            try
            {
                SubCategory objSubCat = _unitOfWork.repoCategory.GetSubCategorySingle(x => x.SubCategoryID == SubCategoryId);
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

                _unitOfWork.BeginTrnsaction();
                _unitOfWork.repoCategory.UpdateSubCategory(objSubCat);
                _unitOfWork.Save();
                _unitOfWork.CommitTransaction();

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
            _unitOfWork = new UnitOfWork();
            try
            {
                SubCategory objCat = _unitOfWork.repoCategory.GetSubCategorySingle(x => x.SubCategoryID == SubCategoryId);
                if (objCat == null)
                {
                    crudResponse = new CrudResponse()
                    {
                        ResponseCode = "400",
                        ResponseMessage = "Not Found"
                    };
                    return crudResponse;
                }
                _unitOfWork.BeginTrnsaction();
                _unitOfWork.repoCategory.DeleteSubCategory(SubCategoryId, objCat);
                _unitOfWork.Save();
                _unitOfWork.CommitTransaction();

                crudResponse = new CrudResponse()
                {
                    ResponseCode = "200",
                    ResponseMessage = "Successfully Deleted"
                };
                return crudResponse;
            }
            catch (Exception ex)
            {
                _unitOfWork.RollbackTransaction();
                throw ex;
            }
        }
    }
}
