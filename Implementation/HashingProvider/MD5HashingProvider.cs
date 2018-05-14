using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuildSchool.PasswordValidationTool.Abstracts;

namespace BuildSchool.PasswordValidationTool.Implementation.HashingProvider
{
    public class MD5HashingProvider : IHashingProvider
    {
        public byte[] ComputeHash(byte[] data)
        {
            var provider = new MD5HashingProvider();
            return provider.ComputeHash(data);
        }
    }
}
