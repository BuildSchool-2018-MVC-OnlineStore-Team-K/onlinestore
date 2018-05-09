﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildSchool.MVCSolution.OnlineStore.Models
{
    class OrderDetail
    {
        public int OrderID { get; set; }
        public int ProductID { get; set; }
        public int UniPrice { get; set; }
        public int Quantity { get; set; }
        public int Discount { get; set; }
    }
}