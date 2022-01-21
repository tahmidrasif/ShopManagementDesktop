using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ShopManagement.BLL.Mapping;
using ShopManagement.BLL.ViewModel;
using ShopManagement.DAL.Model;
using ShopManagement.DAL.Repository;

namespace ShopManagement.BLL
{
    public class VendorBLL
    {
        private UnitOfWork _unitOfWork;
        //IMapper mapper = null;
        public VendorBLL()
        {
            
            //Initialize the mapper
            //var config = new MapperConfiguration(cfg =>
            //{
            //    cfg.CreateMap<Vendor, VendorViewModel>()
            //    .ForMember(dest=>dest.VendorName,source=>source.MapFrom(x=>x.Name))
            //    .ForMember(dest => dest.Address, source => source.MapFrom(x => x.Address1))
            //    .ForMember(dest => dest.PhoneNo, source => source.MapFrom(x => x.Mobile1));
            //    //cfg.CreateMap<>
            //});

            //mapper = config.CreateMapper();
        }


        public string InsertVendor(VendorViewModel vendorVM)
        {
            _unitOfWork = new UnitOfWork();
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
                //_unitOfWork.RollbackTransaction();
                return exception.Message;
            }

        }

        public List<VendorViewModel> GetAllVendors()
        {
            _unitOfWork = new UnitOfWork();
            try
            {
                var vendors = _unitOfWork.repoVendor.GetAllVendors();
                var map= MappingConfig.Mapper.Map<List<Vendor>,List<VendorViewModel>>(vendors);
                return map;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }

        private bool IsVendorAlreadyAvaliable(string p1, string p2)
        {
            throw new NotImplementedException();
        }
    }

    //var config = new MapperConfiguration(cfg => { cfg.CreateMap<AuthorModel, AuthorDTO>(); }); IMapper iMapper = config.CreateMapper(); var source = new AuthorModel(); source.Id = 1;source.FirstName = "Joydip";source.LastName = "Kanjilal";source.Address = "India";var destination = iMapper.Map<AuthorModel, AuthorDTO>(source); Console.WriteLine("Author Name: "+ destination.FirstName + " " + destination.LastName);
}
