using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels
{
    public class RegisterModel
    {
        public string UserName { get; set; }
        public string Address { get; set; }
        public DateTime Birthday { get; set; }
        public int CreditCard { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string UserAccount { get; set; }
        public string UserPwd { get; set; }
        public int Block { get; set; }
        public string Career { get; set; }
    }
}
