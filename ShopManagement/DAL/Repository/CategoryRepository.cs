using System.Data.Entity;
using ShopManagement.BLL.Response;
using ShopManagement.DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.DAL.Repository
{
    public class CategoryRepository : BaseRepository
    {
        //public CategoryRepository(ShopDBEntities context)
        //{
        //    db = context;
        //}
        public CategoryRepository()
        {
           
        }

        public List<Category> GetAllCategories()
        {
            return db.Category.Where(x => x.IsActive == true).ToList();
        }

        public List<Category> GetCategoryByNameOrCode(Expression<Func<Category, bool>> expression)
        {
            if (expression == null)
            {
                return db.Category.Where(x => x.IsActive == true).ToList();
            }
            return db.Category.Where(expression).Where(x => x.IsActive == true).ToList();
        }

        public Category GetCategory(Expression<Func<Category, bool>> expression)
        {
            if (expression != null)
            {
                return db.Category.Where(x => x.IsActive == true).FirstOrDefault(expression);
            }
            return null;
        }

        public void Add(Category oCategory)
        {
            db.Category.Add(oCategory);
        }

        public void Update(Category objCat)
        {
            db.Entry(objCat).State = EntityState.Modified;
        }

        public void Delete(long CategoryId, Category objCat)
        {
            objCat.IsActive = false;
            db.Entry(objCat).State = EntityState.Modified;
        }

        public List<SubCategory> GetSubCategory(Expression<Func<SubCategory, bool>> expression)
        {
            if (expression == null)
            {
                var subcat = db.SubCategory.Where(x => x.IsActive == true).ToList();
                return subcat;// db.SubCategory.Where(x => x.IsActive == true).ToList();
            }
            return db.SubCategory.Where(expression).Where(x => x.IsActive == true).ToList();
        }

        public SubCategory GetSubCategorySingle(Expression<Func<SubCategory, bool>> expression)
        {
            if (expression == null)
            {
                return db.SubCategory.FirstOrDefault(x => x.IsActive == true);
            }
            return db.SubCategory.Where(expression).FirstOrDefault(x => x.IsActive == true);
        }

        public void AddSubCategory(SubCategory oCategory)
        {
            db.SubCategory.Add(oCategory);
        }
        public void UpdateSubCategory(SubCategory objCat)
        {
            db.Entry(objCat).State = EntityState.Modified;
        }

        public void DeleteSubCategory(long SubCategoryId, SubCategory objSubCat)
        {
            objSubCat.IsActive = false;
            db.Entry(objSubCat).State = EntityState.Modified;
        }
    }
}
