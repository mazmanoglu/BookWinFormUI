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

        public void AddNewBook(Book book)
        {
            ds.AddNewBook(book);
        }
    }
}
