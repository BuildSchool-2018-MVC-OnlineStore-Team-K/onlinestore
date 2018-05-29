using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuildSchool.MVCSolution.OnlineStore.Models;
using BuildSchool.MVCSolution.OnlineStore.Repository;
using ViewModels;

namespace Service
{
    public class CheckMember
    {
        public bool CheckAccountRegister(string Account)
        {
            var repository = new MembersRepository();
            

            if (Account.Length <8 || Account.Length>16)
            {
                return false;
            }
            
            if(!repository.CheckAccountIsNotExist(Account))
            {
                return false;
            }

            return true;
        }

        public bool CheckPasswordRegister(string Password)
        {
            if(Password.Length<6 || Password.Length > 16)
            {
                return false;
            }
            return true;
        }

        public bool CheckPhoneRegister(string Phone)
        {
            if (Phone.Length != 10)
            {
                return false;
            }
            return true;
        }

        public bool CheckCreateAccount(RegisterModel members)
        {
            var repository = new MembersRepository();
            if (!repository.CreateAccount(members))
            {
                return false;
            }
            else
            {
                return true;
            }
        }


    }
}
