using BusinessObject;
using BusinessObject.Interfaces;
using System.Collections.Generic;

namespace DataAccessLayer.Interfaces
{
    public interface IDalServices
    {
        void AddLog(string message);
        void AddNewBook(IBook book);
        IEnumerable<IBook> GetBooks();
        IEnumerable<DtoBook> GetBooksByCountry(int id);
        IEnumerable<ICountry> GetCountries();
        void UpdateTheBook(IBook book);
    }
}