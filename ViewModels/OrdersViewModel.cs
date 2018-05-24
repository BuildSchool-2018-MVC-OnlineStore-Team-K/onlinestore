using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels
{
    public class OrdersViewModel
    {
        public DateTime Time { get; set; }
        public int OrderId { get; set; }
        public string Payway { get; set; }
        //缺出貨日期
        public int UnitPrice { get; set; }
        public int Quantity { get; set; }
        public float Discount { get; set; }
    }
}
