using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLogicLayer;
using BusinessObject;

namespace BookWinFormUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            BllServices bllServices = new BllServices();
            var allCountries = bllServices.GetCountries();
            cmbCountry.DataSource = allCountries;
        }

        private void btnAddBook_Click(object sender, EventArgs e)
        {
            BllServices bllServices = new BllServices();

            Book newBook = new Book();
            newBook.Title = txtTitle.Text;
            newBook.Author = txtAuthor.Text;
            newBook.Description = txtDescription.Text;
            newBook.Price = decimal.Parse(txtPrice.Text); // ya da convert.todecimal
            newBook.DatePublished = Convert.ToDateTime(dtpDatePublished.Text);
            newBook.CountryId = cmbCountry.SelectedIndex+1; // cunku ulkeleri 1'den baslattik, ama index herzaman 0'dan baslar.

            bllServices.AddNewBook(newBook);
        }
    }
}
