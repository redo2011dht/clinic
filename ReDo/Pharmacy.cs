using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReDo
{
    public class Pharmacy
    {
        public string id { get; set; }
        public string name { get; set; }
        public string unit { get; set; }
        public int quantity { get; set; }
        public int price { get; set; }
        public int sum
        {
            get
            {
                return price*quantity;
            }
            set
            {
                this.sum = value;
            }
        }
        public string manufactureddate { get; set; }
        public string expireddate { get; set; }
       
     
    }
}
