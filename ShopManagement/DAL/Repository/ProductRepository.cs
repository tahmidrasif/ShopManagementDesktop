using ShopManagement.DAL.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.DAL.Repository
{
    public class ProductRepository:BaseRepository
    {
        public ProductRepository()
        {

        }

        public List<Product> GetAllByProductCode(string productCode)
        {
            List<Product> lstProducts = new List<Product>();

            if (!string.IsNullOrEmpty(productCode))
            {
                lstProducts = db.Product.Where(x => x.ProductCode == productCode).ToList();
                return lstProducts;
            }

            return lstProducts;

        }

        public Product GetProduct(long productId)
        {
            Product product = new Product();

            if (productId > 0)
            {
                product = db.Product.FirstOrDefault(x => x.ProductID == productId);
                return product;
            }

            return product;

        }

        public List<Product> GetAll()
        {
            return db.Product.Where(x => x.IsActive == true).ToList();
        }

        public ProductPrice GetSingleProductPrice(long productId)
        {
            return db.ProductPrice.FirstOrDefault(x => x.IsActive == true && x.ProductID == productId);
        }

        public Product GetSingleByProductName(string productName)
        {
            return db.Product.FirstOrDefault(x => x.IsActive == true && x.Name == productName);
        }

        public List<Product> GetListByProductName(string productName)
        {
            return db.Product.Where(x => x.IsActive == true && x.Name.Contains(productName)).ToList() ;
        }

        public Product GetSingleByProductCode(string productCode)
        {
            return db.Product.FirstOrDefault(x => x.IsActive == true && x.ProductCode == productCode);
        }

        public void Insert(Product objProduct)
        {
            try
            {
                db.Product.Add(objProduct);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public void InsertProductPrice(ProductPrice objProductPrice)
        {
            try
            {
                db.ProductPrice.Add(objProductPrice);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        internal void Update(Product objProduct)
        {
            try
            {
                db.Entry(objProduct).State = EntityState.Modified;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        internal void UpdateProductPrice(ProductPrice objProductPrice)
        {
            try
            {
                db.Entry(objProductPrice).State = EntityState.Modified;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        internal void Delete(Product objProduct)
        {
            try
            {
                db.Entry(objProduct).State = EntityState.Modified;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
