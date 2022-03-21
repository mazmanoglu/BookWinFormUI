using System;
using System.Collections.Generic;
using BusinessLogicLayer.Interfaces;
using BusinessObject;
using BusinessObject.Interfaces;
using DataAccessLayer;
using DataAccessLayer.Interfaces;

namespace BusinessLogicLayer
{
    public class BllServices : IBllServices
    {
        readonly IDalServices ds = new DalServices();
        public IEnumerable<ICountry> GetCountries()
        {
            var countries = ds.GetCountries();
            return countries;
        }
        public bool AddNewBook(IBook book)
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
        public IEnumerable<IBook> GetBooks()
        {
            var books = ds.GetBooks();
            return books;
        }
        public IEnumerable<DtoBook> GetBooksByCountry(int id)
        {
            return ds.GetBooksByCountry(id);
        }
        public void AddLog(string message)
        {
            ds.AddLog(message);
        }
        public bool UpdateTheBook(IBook book)
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
