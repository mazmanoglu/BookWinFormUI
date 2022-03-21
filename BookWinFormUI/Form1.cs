using System;
using System.Windows.Forms;
using BusinessLogicLayer;
using BusinessLogicLayer.Interfaces;
using BusinessObject;
using BusinessObject.Interfaces;

namespace BookWinFormUI
{
    public partial class Form1 : Form
    {
        IBllServices bllServices = new BllServices(); // bunu normalde tum butonlarin icine ayri ayri yazmistik
        // kodu daha guzel hale getirmek icin buraya yazdik. digerlerini ayri ayri yazmaya ihtiyac kalmadi

        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            var allCountries = bllServices.GetCountries();
            cmbCountry.DataSource = allCountries;
            dtgData.DataSource = bllServices.GetBooks();
        }
        private void btnAddBook_Click(object sender, EventArgs e)
        {
            try
            {
                //IBllServices bllServices = new BllServices();

                IBook newBook = new Book();
                newBook.Title = txtTitle.Text;
                newBook.Author = txtAuthor.Text;
                newBook.Description = txtDescription.Text;
                newBook.Price = decimal.Parse(txtPrice.Text); // ya da convert.todecimal
                newBook.DatePublished = Convert.ToDateTime(dtpDatePublished.Text);
                newBook.CountryId = cmbCountry.SelectedIndex + 1; // cunku ulkeleri 1'den baslattik, ama index herzaman 0'dan baslar.

                if (bllServices.AddNewBook(newBook))
                {
                    MessageBox.Show("Record added to the Database");
                }
                else
                {
                    MessageBox.Show("There is a problem to save the record. Try again.");
                    // bunu ekledik cunku bllservice'de tarihle alakali if/else kullandik. 
                    // orada verecek hatayi da burada gostertmis olduk.
                }

                // bllServices.AddNewBook(newBook); bunu sildik cunku program hata verse de bilgiyi ekliyordu.

                dtgData.DataSource = bllServices.GetBooks(); // DB'deki veriyi Datagrid tablosunda gosterme
                                                             // bundan once sql'de sp olusturduk
                                                             // bu sp'yi once dalservices'da sonra da bllservices'da cagirdik.  
            }
            catch (Exception ex)
            {
                //IBllServices bllServices = new BllServices();
                bllServices.AddLog(ex.Message);

                // MessageBox.Show(ex.Message);
                MessageBox.Show("There is a problem with the APP.");
                // yukaridakini secseydik programin herhangi bir yerinde hata oldugunda (tarih hatasi haric)
                // sistem ne hatasi oldugunu kullaniciya gosterecekti. ancak bu sekilde kullaniciya kendi belirledigimiz
                // hata mesajini gosteriyoruz.

            }
        }
        private void btnGetPerCountry_Click(object sender, EventArgs e)
        {
            //IBllServices bllServices = new BllServices();
            var index = cmbCountry.SelectedIndex + 1;
            var books = bllServices.GetBooksByCountry(index);
            dtgData.DataSource = null;
            dtgData.DataSource = books;
        }
        private void dtgData_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //string columnName = dtgData.Columns[e.ColumnIndex].ToString();

            // First way
            int selectedArea = dtgData.SelectedCells[0].RowIndex;
            var rowSelected = dtgData.Rows[selectedArea];
            txtTitle.Text = rowSelected.Cells["Title"].Value.ToString();
            txtAuthor.Text = rowSelected.Cells["Author"].Value.ToString();
            txtDescription.Text = rowSelected.Cells["Description"].Value.ToString();
            txtPrice.Text = rowSelected.Cells["Price"].Value.ToString();
            dtpDatePublished.Text = rowSelected.Cells["DatePublished"].Value.ToString();
            cmbCountry.SelectedIndex = rowSelected.Cells["CountryId"].Value.GetHashCode() - 1;
            //cmbCountry.SelectedIndex = Convert.ToInt32(rowSelected.Cells["CountryId"].Value.ToString()) - 1;


            // second way
            // txtTitle.Text = dtgData.CurrentRow.Cells[1].Value.ToString();
            //txtDescription.Text = dtgData.CurrentRow.Cells[4].Value.ToString();
            //txtPrice.Text = dtgData.CurrentRow.Cells[3].Value.ToString();
            //txtAuthor.Text = dtgData.CurrentRow.Cells[2].Value.ToString();
            //string countryIDString = dtgData.CurrentRow.Cells[5].Value.ToString();
            //int countryId = Convert.ToInt32(countryIDString);
            //cmbCountry.SelectedIndex = countryId-1;
            //dtpDatePublished.Text = dtgData.CurrentRow.Cells[6].Value.ToString();


            // third way
            //var row = dtgData.Rows[e.RowIndex];
            //txtTitle.Text = row.Cells["Title"].Value.ToString();
            //txtAuthor.Text = row.Cells["Author"].Value.ToString();
            //txtDescription.Text = row.Cells["Description"].Value.ToString();
            //txtPrice.Text = row.Cells["Price"].Value.ToString();
            //dtpDatePublished.Text = row.Cells["DatePublished"].Value.ToString();
            //cmbCountry.SelectedIndex = Convert.ToInt32(row.Cells["CountryId"].Value.ToString()) - 1;
            // cmbCountry.SelectedIndex = row.Cells["CountryId"].Value.GetHashCode()-1;
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                BllServices bllServices = new BllServices();

                Book newBook = new Book();
                newBook.Id = Convert.ToInt32(dtgData.CurrentRow.Cells[0].Value.ToString());
                newBook.Title = txtTitle.Text;
                newBook.Author = txtAuthor.Text;
                newBook.Description = txtDescription.Text;
                newBook.Price = decimal.Parse(txtPrice.Text);
                newBook.DatePublished = Convert.ToDateTime(dtpDatePublished.Text);
                newBook.CountryId = cmbCountry.SelectedIndex + 1;

                if (bllServices.UpdateTheBook(newBook))
                {
                    MessageBox.Show("Database updated");
                }
                else
                {
                    MessageBox.Show("There is a problem on update. Try again.");
                }

                dtgData.DataSource = bllServices.GetBooks();
            }
            catch (Exception ex)
            {
                BllServices bllServices = new BllServices();
                bllServices.AddLog(ex.Message);

                MessageBox.Show("There is a problem with the APP.");
            }

        }
    }
}
