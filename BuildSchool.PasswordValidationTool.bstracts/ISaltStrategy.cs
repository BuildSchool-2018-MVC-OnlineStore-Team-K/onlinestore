using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildSchool.PasswordValidationTool.Abstracts
{
    public interface ISaltStrategy
    {
        string Format(string passwordBody,string data);  //string data:把料加進去
        byte[] Format(byte[] passwordData,byte[] saltData);  //byte[] saltData:把料加進去
    }
}
