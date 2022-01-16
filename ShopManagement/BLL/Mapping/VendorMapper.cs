using AutoMapper;
using ShopManagement.BLL.ViewModel;
using ShopManagement.DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.BLL.Mapping
{
    public static class VendorMapper
    {
        public static void Configure(IMapperConfigurationExpression cfg)
        {
            cfg.CreateMap<Vendor, VendorViewModel>()
                            .ForMember(dest => dest.VendorName, source => source.MapFrom(x => x.Name))
                            .ForMember(dest => dest.Address, source => source.MapFrom(x => x.Address1))
                            .ForMember(dest => dest.PhoneNo, source => source.MapFrom(x => x.Mobile1));
        }
    }
}
