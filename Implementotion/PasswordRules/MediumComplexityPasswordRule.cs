using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using BuildSchool.PasswordValidationTool.Abstracts;

namespace Implementotion.PasswordRules
{
    public class MediumComplexityPasswordRule : IPasswordRule
    {
        private const int LeastLenght = 8;
        private string PasswordCharBase = "234565789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ@#$%^&!";

        public string Generate()
        {
            var random = new Random();
            var passwordBuilder = new StringBuilder();

            do  //密碼規則
            {
                passwordBuilder.Clear();

                while (passwordBuilder.Length < LeastLenght)  //長度未符合時就繼續產生(加入)密碼
                {
                    var idx = random.Next(0, PasswordCharBase.Length - 1);
                    passwordBuilder.Append(PasswordCharBase[idx]);
                }
            } while (!Validate(passwordBuilder.ToString()));  //判斷密碼是否存在
            return passwordBuilder.ToString();
        }

        public bool Validate(string password)
        {
            var regex = new Regex(@"((?=.*\d)(?=.*[a-z]).{8,})");  //d表是數字  任意[a-z]中間所有的字元  ?表示至少一個  8是長度  *代表全部(ex.大小寫)
            return regex.IsMatch(password);  //看傳入的值與regex(規則)有沒有吻合
        }
    }
}
