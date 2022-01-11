using ShopManagement.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.BLL
{
    public class ProductPurchaseBLL
    {
        private readonly UnitOfWork _unitOfWork;

        public ProductPurchaseBLL()
        {
            _unitOfWork = new UnitOfWork();
        }
    }
}
