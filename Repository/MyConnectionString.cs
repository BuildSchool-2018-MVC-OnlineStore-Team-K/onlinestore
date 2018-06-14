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
        
        
        public string connect = Environment.GetEnvironmentVariable("SQLAZURECONNSTR_cloud");
        public string connectcloud = "Server=buildschool.database.windows.net;Database=bs-team2;User ID=bsteam2;Password=@bsTp22B#;";


        //public string connect2 = "Server=192.168.40.35,1433;Database=E-Commerce;User ID =smallhandsomehandsome; Password =123;";

    }
}
