using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObject;
using DataAccessLayer;

namespace BusinessLogicLayer
{
    public class BllServices
    {
        DalServices ds = new DalServices();
        public List<Country> GetCountries()
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

        public List<Book> GetBooks()
        {
            var books = ds.GetBooks();
            return books;
        }

        public List<DtoBook> GetBooksByCountry(int id)
        {
            return ds.GetBooksByCountry(id);
        }

        public void AddLog (string message)
        {
            ds.AddLog(message);
        }
    }
}
