using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels
{
    //  [Time] ,p.ProductName, Quantity , Total , p.ProductID , p.UnitPrice , sc.Stock , sc.Color , sz.SizeType , p.Category 
    public class CartViewModel
    {
        public string ProductName  { get; set; }
        public int UnitPrice { get; set; }
        public int Quantity { get; set; }
        public string Color { get; set; }
    }
}
