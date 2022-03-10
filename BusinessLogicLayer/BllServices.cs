using System;
using System.Collections.Generic;
using BusinessObject;
using DataAccessLayer;

namespace BusinessLogicLayer
{
    public class BllServices
    {
        readonly DalServices ds = new DalServices();
        public IEnumerable<Country> GetCountries()
        {
            var countries = ds.GetCountries();
            return countries;
        }
        public bool AddNewBook(Book book)
        {
            bool ok = false;
            try
            {
                if (book.DatePublished < DateTime.Now)
                {
                    ds.AddNewBook(book);
                    ok = true;
                    return ok;
                }
            }
            catch (Exception)
            {
                ok = false;
                //return ok;
                throw;
            }

            return ok;
        }
        public IEnumerable<Book> GetBooks()
        {
            var books = ds.GetBooks();
            return books;
        }
        public IEnumerable<DtoBook> GetBooksByCountry(int id)
        {
            return ds.GetBooksByCountry(id);
        }
        public void AddLog (string message)
        {
            ds.AddLog(message);
        }
        public bool UpdateTheBook(Book book)
        {
            bool ok = false;
            try
            {
                if (book.DatePublished < DateTime.Now)
                {
                    ds.UpdateTheBook(book);
                    ok = true;
                    return ok;
                }
            }
            catch (Exception)
            {
                ok = false;
                //return ok;
                throw;
            }
            return ok;
        }
    }
}
