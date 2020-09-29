using ShopManagement.BLL.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.BLL.Response
{
    public class CategorySearchResponse
    {
        public string ResponseCode { get; set; }
        public List<CategoryVM> CategoryVM { get; set; }
    }
}
