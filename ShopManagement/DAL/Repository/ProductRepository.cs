using ShopManagement.DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.DAL.Repository
{
    public class ProductRepository
    {
        private ShopDBEntities db;
        public ProductRepository(ShopDBEntities context)
        {
            db = context;
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

            if (productId>0)
            {
                product = db.Product.FirstOrDefault(x => x.ProductID == productId);
                return product;
            }

            return product;

        }

        public List<Product> GetAll()
        {
            return db.Product.Where(x => x.IsActive==true).ToList();
        }
    }
}
