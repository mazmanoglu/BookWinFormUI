using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogicLayer;
using BusinessLogicLayer.Interfaces;
using BusinessObject;
using BusinessObject.Interfaces;

namespace ConsoleUI
{
    internal class Program
    {
        private static IBllServices bllServices = new BllServices();
        static void Main(string[] args)
        {
            //ShowAllCountries();
            //ShowAllBooks();
            //GetBooksPerCountry();
            //AddNewBook();
            //UpdateBook();

            Console.ReadLine();
        }

        private static void UpdateBook()
        {
            Console.WriteLine();
            IBook newBook = new Book();
            Console.WriteLine("write ID");
            newBook.Id = int.Parse(Console.ReadLine());
            Console.WriteLine("Write new name of the book");
            newBook.Title = Console.ReadLine();
            Console.WriteLine("Write the name of author");
            newBook.Author = Console.ReadLine();
            Console.WriteLine("Write the description of the book");
            newBook.Description = Console.ReadLine();
            Console.WriteLine("Write the publish date");
            newBook.DatePublished = Convert.ToDateTime(Console.ReadLine());
            Console.WriteLine("Write the country Id");
            newBook.CountryId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("write the price of the book");
            newBook.Price = Convert.ToDecimal(Console.ReadLine());


            bllServices.UpdateTheBook(newBook);

        }
        private static void GetBooksPerCountry()
        {
            Console.WriteLine("\n---------Get Books per Country--------------\n");
            Console.WriteLine("Write the counrty id to see the books");
            int countryId = int.Parse(Console.ReadLine());
            var allBooks = bllServices.GetBooksByCountry(countryId);
            foreach (var book in allBooks)
            {
                Console.WriteLine(book);
            }
        }
        private static void ShowAllCountries()
        {
            Console.WriteLine("---------List of all countries------------\n");
            //IBllServices bllServices = new BllServices();
            var allCountries = bllServices.GetCountries();
            //IEnumerable<ICountry> allCountries = bllServices.GetCountries(); // Var yerine bu da yazilabilir
            foreach (var country in allCountries)
            {
                Console.WriteLine(country);
            }
        }
        private static void ShowAllBooks()
        {
            Console.WriteLine("\n-----------List of all books--------------\n");
            //IBllServices bllServices = new BllServices();
            var allBooks = bllServices.GetBooks();
            foreach (var book in allBooks)
            {
                Console.WriteLine(book);
            }
        }
        private static void AddNewBook()
        {
            Console.WriteLine();
            IBook newBook = new Book();
            Console.WriteLine("Write the name of the book");
            newBook.Title = Console.ReadLine();
            Console.WriteLine("Write the name of author");
            newBook.Author = Console.ReadLine();
            Console.WriteLine("Write the description of the book");
            newBook.Description = Console.ReadLine();
            Console.WriteLine("Write the publish date");
            newBook.DatePublished = Convert.ToDateTime(Console.ReadLine());
            Console.WriteLine("Write the country Id");
            newBook.CountryId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("write the price of the book");
            newBook.Price = Convert.ToDecimal(Console.ReadLine());


            bllServices.AddNewBook(newBook);
        }
    }
}
// app.config'e baglanti ekledik.
