using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.BLL.Request
{
    public class CategoryEntryRequest:BaseEntryRequest
    {
        public string CategoryCode { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
    }
}
