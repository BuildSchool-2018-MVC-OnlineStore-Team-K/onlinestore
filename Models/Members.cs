using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildSchool.MVCSolution.OnlineStore.Models
{
    public class Members
    {
        public int MemberID { get; set; }
        public string MemberName { get; set; }
        public string Address { get; set; }
        public DateTime Birthday { get; set; }
        public int CreditCard { get; set; }
        public int Phone { get; set; }
        public string Email { get; set; }
        public string Account { get; set; }
        public string Password { get; set; }
        public string Block { get; set; }
        public string Career { get; set; }
    }
}