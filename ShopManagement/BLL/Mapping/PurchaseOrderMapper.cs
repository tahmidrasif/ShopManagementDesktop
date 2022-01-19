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
    public static class PurchaseOrderMapper
    {
        public static void Configure(IMapperConfigurationExpression cfg)
        {
            cfg.CreateMap<PurchaseOrder, PurchaseOrderVM>().
                ForMember(dest => dest.OrderList, source => source.MapFrom(x => x.PurchaseOrderDetails))
                .ReverseMap();


                //.ForMember(dest => dest., source => source.MapFrom(x => x.Name)) PurchaseOrderDetails


        }
    }
}
