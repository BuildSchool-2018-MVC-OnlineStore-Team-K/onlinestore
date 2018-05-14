using BuildSchool.PasswordValidationTool.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildSchool.PasswordValidationTool.Implementation.SaltStrategy
{
    public class DefaultSaltStrategy : ISaltStrategy
    {
        public string Format(string passwordBody)
        {
            throw new NotImplementedException();
        }

        public byte[] Format(byte[] passwordData)
        {
            throw new NotImplementedException();
        }
    }
}
