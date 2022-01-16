﻿using AutoMapper;
using ShopManagement.BLL.ViewModel;
using ShopManagement.DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.BLL.Mapping
{
    public static class MappingConfig
    {
        public static IMapper Mapper;
        public static void InitializeAutoMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                VendorMapper.Configure(cfg);

            });

            Mapper = config.CreateMapper();
        }

        
    }
}
