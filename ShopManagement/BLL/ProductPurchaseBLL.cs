using ShopManagement.BLL.Mapping;
using ShopManagement.BLL.ViewModel;
using ShopManagement.DAL.Model;
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

        public string PlaceOrder(PurchaseOrderVM purchaseOrderVm)
        {
            if (purchaseOrderVm != null)
            {
                PurchaseOrder oPo = new PurchaseOrder();
                oPo.PurchaseOrderDetails = new List<PurchaseOrderDetails>();
                var map = MappingConfig.Mapper.Map(purchaseOrderVm,oPo);
            }
            return "Success";
        }
    }
}
