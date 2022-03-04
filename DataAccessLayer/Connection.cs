using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace DataAccessLayer
{
    public static class Connection
    {
        public static string GetConnection(string name) // static yaptik cunku instantie yapmak isstemiyoruz.
        {
            return ConfigurationManager.ConnectionStrings[name].ConnectionString;
        }
    }
}
