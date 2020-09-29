using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopManagement.BLL.ViewModel;

namespace ShopManagement.BLL.Response
{
    public class SubCatSearchResponse
    {
        public string ResponseCode { get; set; }
        public List<SubCatVM> SubCategoryVM { get; set; }
    }
}
