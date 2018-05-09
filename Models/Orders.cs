using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildSchool.MVCSolution.OnlineStore.Models
{
    //jfdklsjfksjkfjskjfksdjfksjfkl
    public class Orders
    {
        public int OrderID { get; set; }
        public int MemberID { get; set; }
        public int OrderDetailID { get; set; }
        public int Cart { get; set; }
        public int Pay { get; set; }
        public DateTime Time { get; set; }
        public string ShipPlace { get; set; }
        public string Payway { get; set; }
    }
}
