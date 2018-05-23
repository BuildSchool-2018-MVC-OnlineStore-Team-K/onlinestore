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
        public double Discount { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}
