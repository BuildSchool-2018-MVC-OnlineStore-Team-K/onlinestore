using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels
{
    public class ProductDetailViewModel
    {
        public string ProductID { get; set; }
        public string ColorID { get; set; }
        public string SizeID { get; set; }

        public string  Category { get; set; }
        public string ProductName { get; set; }
        public int UnitPrice { get; set; }
        public string SizeType { get; set; }
        public string Color { get; set; }
        public int Stock { get; set; }
    }
}
