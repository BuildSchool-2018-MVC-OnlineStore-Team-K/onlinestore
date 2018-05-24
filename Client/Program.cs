using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using BuildSchool.PasswordValidationTool.Abstracts;
using BuildSchool.PasswordValidationTool.Client;
using BuildSchool.PasswordValidationTool.Implementation.HashingProvider;
using BuildSchool.PasswordValidationTool.Implementation.PasswordRules;
using BuildSchool.PasswordValidationTool.Implementation.SaltStrategy;
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
            container.Register<IPasswordValidationService, PasswordValidationService>();

            // resolve object and get instance.
            var service =
                container.GetInstance<IPasswordValidationService>();

            //var pwd = service.GeneratePassword();
            var userInputPwd = "6qn84tNe";
            var storedPwd = "6qn84tNe";
            

            var randomGenerator = new RNGCryptoServiceProvider();
            //16位元的加料
            var salt = new byte[16];
            //讓salt更隨機
            randomGenerator.GetBytes(salt);

            //emulate stored password 
            //資料庫的密碼轉為byte
            byte[] storedPwdData = Encoding.UTF8.GetBytes(storedPwd);
            //將byte的資料庫的密碼雜湊
            byte[] storedPwdHashed = service.HashPassword(storedPwdData, salt);

            //valid user input
            //將user輸入ㄉ密碼轉為byte
            byte[] userPwdData = Encoding.UTF8.GetBytes(userInputPwd);

            //呼叫 ValidatePassword       傳入資料庫的密碼, 使用者輸入的, 加料
            if (service.ValidatePassword(storedPwdHashed, userPwdData, salt))
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
