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
        public string SizeType { get; set; }
        public string Color { get; set; }
        public int? Stock { get; set; }
        public string Picture { get; set; }
    }

    public class ProductsDetailViewModel
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public string Category { get; set; }
        public int? UnitPrice { get; set; }
        public string Picture { get; set; }
    }

    public class ProductSize
    {
        public string SizeType { get; set; }
    }

    public class ProductColor
    {
        public string Color { get; set; }
    }

    public class ProductColorStock
    {
        public int? Stock { get; set; }
    }

    public class ProductHomeViewModel
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public int UnitPrice { get; set; }
        public int Sum { get; set; }
    }
}
