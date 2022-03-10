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
