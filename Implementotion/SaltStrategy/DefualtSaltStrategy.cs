using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuildSchool.PasswordValidationTool.Abstracts;

namespace Implementotion.SaltStrategy
{
    public class DefualtSaltStrategy : ISaltStrategy
    {
        public string Format(string passwordBody, string salt)
        {            
                var bodyData = Encoding.UTF8.GetBytes(passwordBody);
                var saltData = Encoding.UTF8.GetBytes(salt);
                var result = Format(bodyData, saltData);

                return Encoding.UTF8.GetString(result);           
        }

        public byte[] Format(byte[] passwordData, byte[] saltData)
        {
            byte[] result = new byte[passwordData.Length+saltData.Length];
            Buffer.BlockCopy(passwordData, 0, result,0,passwordData.Length);
            Buffer.BlockCopy(saltData, 0, result,passwordData.Length,saltData.Length);
            return result;
        }
    }
}
