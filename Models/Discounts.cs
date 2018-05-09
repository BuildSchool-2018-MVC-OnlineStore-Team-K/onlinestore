using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildSchool.MVCSolution.OnlineStore.Models
{
    public class Discounts
    {
        public int DiscountID { get; set; }
        public int ProductID { get; set; }
        public int Discount { get; set; }
        public int StartTime { get; set; }
        public int EndTime { get; set; }
    }
}
