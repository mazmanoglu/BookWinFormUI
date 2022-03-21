using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using Dapper;
using System.Data.SqlClient;
using System.Data;
using BusinessObject.Interfaces;
using DataAccessLayer.Interfaces;

namespace DataAccessLayer
{
    public class DalServices : IDalServices
    {
        public IEnumerable<ICountry> GetCountries()
        {
            using (IDbConnection connection = new SqlConnection(Connection.GetConnection("Books")))
            {
                var countries = connection.Query<Country>("spGetAllCountries", commandType: CommandType.StoredProcedure).ToList();
                return countries;
            }
        }
        public IEnumerable<IBook> GetBooks()
        {
            using (IDbConnection connection = new SqlConnection(Connection.GetConnection("Books")))
            {
                var books = connection.Query<Book>("spGetAllBooks", commandType: CommandType.StoredProcedure).ToList();
                return books;
            }
        }
        public void AddNewBook(IBook book)
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
                try
                {
                    connection.Execute("spAddNewBook", param, commandType: CommandType.StoredProcedure);
                    //connection.Execute("spAddNewBookk", param, commandType: CommandType.StoredProcedure); burayi yanlis yazinca sistem ne hatasi oldugunu bize gosteriyor.
                    // ama mesela tarihi yanlis girdigimizde bizim daha onceden yazdigimiz hata mesahini gosteriyor.
                    // programa sonradan Log metodu ve spLog ekledik. bu sayede kullaniciya sadece hata oldugunu soyluyoruz
                    // ancak program bu hatayi kendi database'imizde olsturdugumuz Log tablosuna ekliyor.
                }
                catch (Exception ex)
                {

                    throw ex;
                }
            }
        }
        public IEnumerable<DtoBook> GetBooksByCountry(int id)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@id", id);

            using (IDbConnection connection = new SqlConnection(Connection.GetConnection("Books")))
            {
                var books = connection.Query<DtoBook, Country, DtoBook>("spGetPerCountry",
                    (dtobook, country) =>
                    {
                        dtobook.CountryId = country;
                        return dtobook;
                    },
                    param, commandType: CommandType.StoredProcedure).ToList();
                return books;
            }
        }
        public void AddLog(string message)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@LogMessage", message);


            using (IDbConnection connection = new SqlConnection(Connection.GetConnection("Books")))
            {
                try
                {
                    connection.Execute("spLog", param, commandType: CommandType.StoredProcedure);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
        public void UpdateTheBook(IBook book)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@Id", book.Id);
            param.Add("@Title", book.Title);
            param.Add("@Author", book.Author);
            param.Add("@Description", book.Description);
            param.Add("@Price", book.Price);
            param.Add("@CountryId", book.CountryId);
            param.Add("@DatePublished", book.DatePublished);

            using (IDbConnection connection = new SqlConnection(Connection.GetConnection("Books")))
            {
                connection.Execute("spUpdateTheInfo", param, commandType: CommandType.StoredProcedure);
            }
        }
    }
}
// readonly collections'lar icin IEnumerable interface'ini kullanmak daha pratik.
// buradaki metodlari ilk basta List ile yapmistik ama simdi onlari IEnumerable ile degistiriyoruz.
// mumkun oldugunca programinda interface kullan.