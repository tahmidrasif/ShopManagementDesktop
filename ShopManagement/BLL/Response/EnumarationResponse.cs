using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.BLL.Response
{
    public class EnumarationResponse
    {
        public long EnumID { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string TypeDecscription { get; set; }
        public string Remarks { get; set; }
        public Nullable<int> EnumOrder { get; set; }
        public Nullable<int> EnumSteps { get; set; }
    }
}
