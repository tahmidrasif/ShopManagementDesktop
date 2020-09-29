using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.BLL.ViewModel
{
    public class CategoryVM
    {
        public long CategoryID { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public string CategoryCode { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CategoryFullName { get; set; }
    }
}
