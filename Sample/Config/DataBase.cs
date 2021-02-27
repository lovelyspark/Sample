using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace Sample.Config
{
    public class DataBase
    {
        public static string  GetConnection()
        {
            return ConfigurationManager.ConnectionStrings["Data"].ConnectionString;
        }
    }
}