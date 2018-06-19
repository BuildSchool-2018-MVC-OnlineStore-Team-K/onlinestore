using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels
{
    public class CreateProductsModel
    {
        public string Category { get; set; }
        public string ProductName { get; set; }
        public int Price { get; set; }
        public string Color { get; set; }
        public int Stock { get; set; }
        public string Size { get; set; }
    }
}
