using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.BLL.Request
{
    public class SubCatUpdateRequest : BaseEntryRequest
    {
        public long SubCategoryID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public long CategoryID { get; set; }
    }
}
