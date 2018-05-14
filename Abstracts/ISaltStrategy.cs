using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildSchool.PasswordValidationTool.Abstracts
{
    public interface ISaltStrategy
    {
        string Format(string passwordBody);
        byte[] Format(byte[] passwordData);
    }
}
