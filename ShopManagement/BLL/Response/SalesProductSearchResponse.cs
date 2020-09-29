using ShopManagement.BLL.ViewModel;
using ShopManagement.DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.BLL.Response
{
    public class SalesProductSearchResponse
    {
        public string ResponseCode { get; set; }
        public string ResponseMessage { get; set; }
        public List<ProductSearchResultVM> ProductSearchVMList { get; set; }
    }
}
