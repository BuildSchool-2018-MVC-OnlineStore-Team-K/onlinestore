using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuildSchool.PasswordValidationTool.Abstracts;

namespace Client
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

        public bool ValidatePassword(byte[] pwd,byte[] pwdCheck,byte[] salt)
        {
            var formattedPwd = _saltStrategy.Format(pwd, salt);
            var hashedPwd = _hashingProvider.ComputeHash(formattedPwd);  //先加過料再作Hash

            if (pwd.Length != hashedPwd.Length)  //如果兩個長度不一樣(輸入/設定)
                return false;

            for(var i = 0; i < pwd.Length; i++)
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
