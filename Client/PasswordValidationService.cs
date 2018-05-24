using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuildSchool.PasswordValidationTool.Abstracts;

namespace BuildSchool.PasswordValidationTool.Client
{
    public class PasswordValidationService : IPasswordValidationService
    {
        private IHashingProvider _hashingProvider;
        private ISaltStrategy _saltStrategy;
        private IPasswordRule _passwordRule;

        public PasswordValidationService(IHashingProvider hashingProvider, ISaltStrategy saltStrategy, IPasswordRule passwordRule)
        {
            _hashingProvider = hashingProvider;
            _saltStrategy = saltStrategy;
            _passwordRule = passwordRule;
        }
        //                     傳入資料庫的密碼 ,  使用者輸入的   ,   加料
        public bool ValidatePassword(byte[] pwd, byte[] pwdCheck, byte[] salt)
        {
            //將使用者輸入的加料
            var formattedPwd = _saltStrategy.Format(pwdCheck, salt); 
            //先加過料再作Hash
            var hashedPwd = _hashingProvider.ComputeHash(formattedPwd);
            //如果兩個長度不一樣(資料庫的和user輸入的)
            if (pwd.Length != hashedPwd.Length)  
                return false;
            //比對每個字元是否正確
            for (var i = 0; i < pwd.Length; i++)
            {
                if (pwd[i] != hashedPwd[i])
                {
                    return false;
                }
            }
            return true;
        }

        public string GeneratePassword()
        {
            return _passwordRule.Generate();
        }

        public byte[] HashPassword(byte[] pwd, byte[] salt)
        {
            var formattedPwd = _saltStrategy.Format(pwd, salt);
            return _hashingProvider.ComputeHash(formattedPwd);
        }
    }
}
