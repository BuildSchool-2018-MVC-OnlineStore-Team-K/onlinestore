using BuildSchool.PasswordValidationTool.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildSchool.PasswordValidationTool.Implementation.HashingProvider
{
    public class SHA512HashingProvider : IHashingProvider
    {
        public byte[] ComputeHash(byte[] data)
        {
            var provider = new SHA512HashingProvider();
            return provider.ComputeHash(data);

        }
    }
}
