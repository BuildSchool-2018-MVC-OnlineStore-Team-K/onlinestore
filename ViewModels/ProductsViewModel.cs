using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels
{
    public class ProductsViewModel
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public string Category { get; set; }
        public int? UnitPrice { get; set; }
        public string Size { get; set; }
        public string Color { get; set; }
        public int? Stock { get; set; }
        public string Picture { get; set; }
    }
}
