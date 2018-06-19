using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels
{
    public class AddToCartViewModel
    {
        public int ProductID { get; set; }
        public int UnitPrice { get; set; }
        public string Color{ get; set; }
        public string Size { get; set; }
        public string Quantity { get; set; }
    }
}
