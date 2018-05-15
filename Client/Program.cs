using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuildSchool.PasswordValidationTool.Implementation.HashingProvider;
using BuildSchool.PasswordValidationTool.Implementation.PasswordRules;
using BuildSchool.PasswordValidationTool.Implementation.SaltStrategy;
using Client;

namespace BuildSchoolPassword.ValidationToolClient.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            var service = new PasswordValidationService(
                new SHA512HashingProvider(), 
                new DefaultSaltStrategy(), 
                new HighComplexityPasswordRule());
            //var pwd = service.GeneratePassword();
            var userInputPwd = "x3n84tNe";
            var storedPwd = "x3n84tNe";
            var salt = "abcde";

            //emulate stored password
            byte[] storedPwdData = Encoding.UTF8.GetBytes(storedPwd);
            byte[] saltData = Encoding.UTF8.GetBytes(salt);
            byte[] storedPwdHashed = service.HashPassword(storedPwdData, saltData);

            //valid user input
            byte[] userPwdData = Encoding.UTF8.GetBytes(userInputPwd);

            if (service.ValidatePassword(storedPwdHashed, userPwdData, saltData))
            {
                Console.WriteLine("Correct");
            }
            else
            {
                Console.WriteLine("Incorrect Pwd.");
            }

            Console.ReadLine();
        }
    }
}
