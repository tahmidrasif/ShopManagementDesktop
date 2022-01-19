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
    public static class PurchaseOrderDetailsMapper
    {
        public static void Configure(IMapperConfigurationExpression cfg)
        {

            cfg.CreateMap<PurchaseOrderDetails, PurchaseOrderDetailsVM>()
                .ForMember(dest => dest.ProductID, source => source.MapFrom(x => x.ProductID))
                .ReverseMap();
        }
    }
}
