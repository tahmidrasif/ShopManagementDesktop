using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.BLL.Response
{
    public class PaymentResponse
    {
        public string ResponseCode { get; set; }
        public string ResponseMessage { get; set; }
        public string OrderNo { get; set; }
    }
}
