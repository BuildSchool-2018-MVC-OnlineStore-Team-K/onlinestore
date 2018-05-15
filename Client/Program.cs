using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuildSchool.PasswordValidationTool.Abstracts;
using BuildSchool.PasswordValidationTool.Implementation.HashingProvider;
using BuildSchool.PasswordValidationTool.Implementation.PasswordRules;
using BuildSchool.PasswordValidationTool.Implementation.SaltStrategy;
using Client;
using SimpleInjector;

namespace BuildSchoolPassword.ValidationToolClient.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            //register dependency
            var container = new Container();
                               //  這個介面     ,      由誰實作
            container.Register<IHashingProvider, SHA512HashingProvider>();
            container.Register<IPasswordRule, MediumComplexityPasswordRule>();
            container.Register<ISaltStrategy, DefaultSaltStrategy>();
            container.Register<IPasswordValidationService>();


            //var service = new PasswordValidationService(
            //    container.GetInstance<IHashingProvider>(),
            //    container.GetInstance<ISaltStrategy>(),
            //    container.GetInstance<IPasswordRule>());
            var service =container.GetInstance<IPasswordValidationService>();

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
