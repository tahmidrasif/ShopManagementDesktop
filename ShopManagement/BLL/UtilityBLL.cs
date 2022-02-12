using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.BLL
{
    public class UtilityBLL
    {
        public string GetSixDigitRandomNumbr()
        {
            Random generator = new Random();
            String r = generator.Next(99999, 10000000).ToString("D6");
            return r;
        }
    }
}
