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
    public class VendorBLL
    {
        private UnitOfWork _unitOfWork;
        public VendorBLL()
        {
            _unitOfWork=new UnitOfWork();
        }


        public string InsertVendor(VendorViewModel vendorVM)
        {
            try
            {
                Vendor oVendor = new Vendor();


                if (vendorVM != null)
                {
                    if (IsVendorAlreadyAvaliable(vendorVM.VendorName,vendorVM.PhoneNo))
                    {
                        return "Vendor is already available";
                    }

                    oVendor.Name = vendorVM.VendorName;
                    oVendor.Mobile1 = vendorVM.PhoneNo;
                    oVendor.Address1 = vendorVM.Address;
                    oVendor.Email = vendorVM.Email;
                  


                    _unitOfWork.repoVendor.Insert(oVendor);
                    _unitOfWork.Save();


                    return "Successfully Inserted the Vendor";
                }
                return "Error in Inserting Vendor";
            }
            catch (Exception exception)
            {
                _unitOfWork.RollbackTransaction();
                return exception.Message;
            }

        }

        private bool IsVendorAlreadyAvaliable(string p1, string p2)
        {
            throw new NotImplementedException();
        }
    }
}
