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
        public List<Book> GetBooks()
        {
            using (IDbConnection connection = new SqlConnection(Connection.GetConnection("Books")))
            {
                var books = connection.Query<Book>("spGetAllBooks", commandType: CommandType.StoredProcedure).ToList();
                return books;
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
        
        public List<DtoBook> GetBooksByCountry(int id)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add ("@id", id);

            using (IDbConnection connection = new SqlConnection(Connection.GetConnection("Books")))
            {
                var books = connection.Query<DtoBook,Country,DtoBook>("spGetPerCountry",
                    (dtobook, country) => 
                    {
                        dtobook.CountryId = country;
                        return dtobook;
                    },
                    param , commandType:CommandType.StoredProcedure).ToList();
                return books;
            }
        }
    }
}
