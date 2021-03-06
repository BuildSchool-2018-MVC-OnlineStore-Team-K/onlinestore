﻿using System;
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
            var userInputPwd = "x2n84tNe";
            var storedPwd = "x2n84tNe";

            var randomGenerator = new RNGCryptoServiceProvider();
            var salt = new byte[16];
            randomGenerator.GetBytes(salt);

            //emulate stored password
            byte[] storedPwdData = Encoding.UTF8.GetBytes(storedPwd);
            byte[] storedPwdHashed = service.HashPassword(storedPwdData, salt);

            //valid user input
            byte[] userPwdData = Encoding.UTF8.GetBytes(userInputPwd);

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
