using BusinessObject;
using BusinessObject.Interfaces;
using System.Collections.Generic;

namespace BusinessLogicLayer.Interfaces
{
    public interface IBllServices
    {
        void AddLog(string message);
        bool AddNewBook(IBook book);
        IEnumerable<IBook> GetBooks();
        IEnumerable<DtoBook> GetBooksByCountry(int id);
        IEnumerable<ICountry> GetCountries();
        bool UpdateTheBook(IBook book);
    }
}