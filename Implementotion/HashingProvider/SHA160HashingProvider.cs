using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using BuildSchool.PasswordValidationTool.Abstracts;

namespace Implementotion.HashingProvider
{
    public class SHA1CryptoServiceProvider : IHashingProvider
    {
        public byte[] ComputeHash(byte[] data)
        {
            var provider = new SHA1CryptoServiceProvider();
            return provider.ComputeHash(data);
        }
    }
}
