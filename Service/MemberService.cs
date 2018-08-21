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
    public class MemberService
    {
        public bool CheckAccountExist(string Account)
        {
            var repository = new MembersRepository();
            
            if(repository.CheckAccountIsExist(Account))
            {
                return true;
            }

            return false;
        }

        public bool CheckAccountAndPasswordRegister(string Account,string Password)
        {
            if (Account.Length < 8 || Account.Length > 16)
            {
                return false;
            }

            if (Password.Length<6 || Password.Length > 16)
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

        public bool CheckFbRegistered(string id)
        {
            var repository = new MembersRepository();
            var result = repository.CheckFbIdExist(id);
            return result;//true = 註冊過 = 有撈到
        }

        public string GetAccountName(string Account,string Password)
        {
            var repository = new MembersRepository();
            return repository.AccountLogin(Account, Password);
        }

        public bool FbRegist(string id , string name )
        {
            var repository = new MembersRepository();
            return repository.CreateAccountByFBId(id, name); //true = 成功
        }

        public IEnumerable<Members> GetMembers()
        {
            var repository = new MembersRepository();
            return repository.GetAll();
        }

    }
}
