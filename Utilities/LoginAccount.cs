using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildSchool.MVCSolution.OnlineStore.Utilities
{
    public class LoginAccount<Members> where Members : class, new()
    {

        public int Acc, Pass;
        public LoginAccount(int Acc, int Pass)
        {
            var repository = new BuildSchool.MVCSolution.OnlineStore.Repository.MembersRepository();
            this.Acc = repository.Account();
            this.Pass = repository.Password();

        }
    }
}
