using BuildSchool.PasswordValidationTool.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BuildSchool.PasswordValidationTool.Implementation.PasswordRules
{
    public class MediumComplexityPasswordRule : IPasswordRule
    {
        private const int LeastLength = 6;
        private const string PasswordCharBase = "23456789abcdefghijklmnpqrstuvwxyzABCDEFGHIJKLMNPQRSTUVWXYZ!@#$%^&";

        public string Generate()
        {
            var random = new Random();
            var passwordBuilder = new StringBuilder();
            do
            {
                passwordBuilder.Clear();
                while (passwordBuilder.Length <= LeastLength)
                {
                    var idx = random.Next(0, PasswordCharBase.Length - 1);
                    passwordBuilder.Append(PasswordCharBase[idx]);
                }
            }
            while (!Validate(passwordBuilder.ToString()));

            return passwordBuilder.ToString();
        }

        public bool Validate(string password)
        {
            var regex = new Regex(@"((?=.*\d)(?=.*[a-z]).{8,})");
            return regex.IsMatch(password);
        }
    }
}
