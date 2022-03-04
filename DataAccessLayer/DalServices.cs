using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Data.SqlClient;
using System.Data;

namespace DataAccessLayer
{
    public class DalServices
    {
        public List<Country> GetCountries()
        {
            using (IDbConnection connection = new SqlConnection(Connection.GetConnection("Books")))
            {
                var countries = connection.Query<Country>("spGetAllCountries", commandType:CommandType.StoredProcedure).ToList();
                return countries;
            }
        }

        public void AddNewBook(Book book)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@Title", book.Title);
            param.Add("@Author", book.Author);
            param.Add("@Description", book.Description);
            param.Add("@Price", book.Price);
            param.Add("@CountryId", book.CountryId);
            param.Add("@DatePublished", book.DatePublished);

            using (IDbConnection connection = new SqlConnection(Connection.GetConnection("Books")))
            {
                connection.Execute("spAddNewBook", param, commandType:CommandType.StoredProcedure);
            }
        }
    }
}
