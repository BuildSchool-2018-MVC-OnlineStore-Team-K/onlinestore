using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using BuildSchool.PasswordValidationTool.Abstracts;

namespace Implementotion.HashingProvider
{
    public class SHA256HashingProvider : IHashingProvider
    {
        public byte[] ComputeHash(byte[] data)
        {
            var provider = new SHA256CryptoServiceProvider();
            return provider.ComputeHash(data);
        }
    }
}
