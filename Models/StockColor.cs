using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildSchool.MVCSolution.OnlineStore.Models
{
    public class StockColor
    {
        public int ColorID { get; set; }
        public int SizeID { get; set; }
        public string Color { get; set; }
        public int Stock { get; set; }
    }
}
