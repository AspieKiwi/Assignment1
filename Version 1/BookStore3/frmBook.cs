using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookStore3
{
    public partial class frmBook : Form
    {
        protected clsAllBooks _Book;
        public delegate void LoadBookFormDelegate(clsAllBooks prBook);

        public static void DispatchBookFrom(clsAllBooks prBook)
        {
            Dictionary<char, Delegate> BooksForm = new Dictionary<char, Delegate>
            {
                {'F', new LoadBookFormDelegate(frmFiction.Run) }
            };
            BooksForm[prBook.BookType].DynamicInvoke(prBook);
        }
        public frmBook()
        {
            InitializeComponent();
        }

        public void SetDetails(clsAllBooks prBook)//(string prISBN, DateTime prDate, decimal prValue, decimal prQuantity, decimal prPageNumbers)
        {
            _Book = prBook;
            updateForm();
            ShowDialog();
        }

        public void GetDetails(ref string prISBN, ref DateTime prDate, ref decimal prValue, ref decimal prQuantity, ref decimal prPageNumbers)
        {
            //prISBN = txtISBN.Text;
            //prDate = Convert.ToDateTime(txtDate.Text);
            //prValue = Convert.ToDecimal(txtValue.Text);
            //prQuantity = Convert.ToDecimal(txtQuantity.Text);
            //prPageNumbers = Convert.ToDecimal(txtPageNumbers.Text);
        }

        private async void btnOK_Click(object sender, EventArgs e)
        {
            if (isValid())
            {
                pushData();
                if (txtTitle.Enabled)
                    MessageBox.Show(await ServiceClient.InsertBookAsync(_Book));
                else
                    MessageBox.Show(await ServiceClient.UpdateBookAsync(_Book));
                Close();
            //}
            //if (isValid() == true)
            //{
            //    DialogResult = DialogResult.OK;
            //    Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            //DialogResult = DialogResult.Cancel;
            Close();
        }

        public virtual bool isValid()
        {
            return true;
        }

        protected virtual void updateForm()
        {
            txtISBN.Text = _Book.ISBN.ToString();
            txtTitle.Text = _Book.BookTitle;
            txtType.Text = _Book.BookType.ToString();
            txtPricePerItem.Text = _Book.PricePerItem.ToString();
            txtDate.Text = _Book.DateLastModified.ToString();
            txtQuantity.Text = _Book.StockQuantity.ToString();
            txtTitle.Enabled = string.IsNullOrEmpty(_Book.BookTitle);
        }

        protected virtual void pushData()
        {
            _Book.ISBN = long.Parse(txtISBN.Text);
            _Book.BookTitle = txtTitle.Text;
            _Book.BookType = char.Parse(txtType.Text);
            _Book.PricePerItem = decimal.Parse(txtPricePerItem.Text);
            _Book.DateLastModified = DateTime.Parse(txtDate.Text);
            _Book.StockQuantity = int.Parse(txtQuantity.Text);
        }
    }

}