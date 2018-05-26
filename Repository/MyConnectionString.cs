using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildSchool.MVCSolution.OnlineStore.Repository
{
    public class MyConnectionString
    {
        public string connectcloud = Environment.GetEnvironmentVariable("SQLAZURECONNSTR_cloud");
        
        //public string connect2 = ConfigurationManager.ConnectionStrings["db"].ConnectionString;
        public string connect = "Server=192.168.0.105,1433;Database=E-Commerce;User ID =smallhandsomehandsome; Password =123;";
    }
}
