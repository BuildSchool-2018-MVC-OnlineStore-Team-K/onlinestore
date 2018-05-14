using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuildSchool.PasswordValidationTool.Abstracts;

namespace Implementotion.PasswordRules
{
    public class LowComplexityPasswordRule : IPasswordRule
    {
        private const int LeastLenght = 6;
        private string PasswordCharBase="234565789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ@#$%^&!";

        public string Generate()
        {
            var random = new Random();
            var passwordBuilder = new StringBuilder();

            do  //密碼規則
            {
                passwordBuilder.Clear();

                while(passwordBuilder.Length<LeastLenght)  //長度未符合時就繼續產生(加入)密碼
                {
                    var idx = random.Next(0, PasswordCharBase.Length - 1);
                    passwordBuilder.Append(PasswordCharBase[idx]);
                }
            } while (!Validate(passwordBuilder.ToString()));  //判斷密碼是否存在
            return passwordBuilder.ToString();
        }
        public bool Validate(string password)  //回傳密碼長度有無在標準之上
        {
            return password.Length >= LeastLenght;
        }
    }
}
