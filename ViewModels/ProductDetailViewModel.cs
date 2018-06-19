using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels
{
    public class ProductDetailViewModel
    {
        public int ProductID { get; set; }
        public int ColorID { get; set; }
        public int SizeID { get; set; }

        public string  Category { get; set; }
        public string ProductName { get; set; }
        public int UnitPrice { get; set; }
        public string SizeType { get; set; }
        public string Color { get; set; }
        public int Stock { get; set; }
    }
}
