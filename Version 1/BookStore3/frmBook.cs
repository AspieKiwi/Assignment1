using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookUniversal
{
    public partial class frmBook : Form
    {
        protected clsAllBooks _Book;

        protected List<string> _VaidationError;
        public delegate void LoadBookFormDelegate(clsAllBooks prBook);

        public static void DispatchBookFrom(clsAllBooks prBook)
        {
            Dictionary<char, Delegate> BooksForm = new Dictionary<char, Delegate>
            {
                {'F', new LoadBookFormDelegate(frmFiction.Run) },
                {'N', new LoadBookFormDelegate(frmNonFiction.Run) }
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
            _VaidationError = new List<string>();
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

        private async void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                _VaidationError.Clear();
                if (IsValid())
                {
                    pushData();
                    if (_Book.ISBN == 0)
                    {
                        if (!await IsISBNTaken())
                        {
                            MessageBox.Show(await ServiceClient.InsertBookAsync(_Book));
                            Close();
                        }
                        else
                            MessageBox.Show(String.Join("\n", _VaidationError), "There are errors with this form:");
                    }
                    else
                    {
                        MessageBox.Show(await ServiceClient.UpdateBookAsync(_Book));
                        Close();
                    }
                }
                else
                    MessageBox.Show(String.Join("\n", _VaidationError), "There are errors with this form:");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n" + ex.StackTrace);
            }
            //if (isValid())
            //{
            //    pushData();
            //    if (txtTitle.Enabled)
            //        MessageBox.Show(await ServiceClient.InsertBookAsync(_Book));
            //    else
            //        MessageBox.Show(await ServiceClient.UpdateBookAsync(_Book));
            //    Close();
            //    //}
            //    //if (isValid() == true)
            //    //{
            //    //    DialogResult = DialogResult.OK;
            //    //    Close();
            //}
        }

        private void btnClose_Click(object sender, EventArgs e)
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
            txtPrice.Text = _Book.PricePerItem.ToString();
            txtDate.Text = _Book.DateLastModified.ToString();
            txtQuantity.Text = _Book.StockQuantity.ToString();
            txtTitle.Enabled = string.IsNullOrEmpty(_Book.BookTitle);
        }

        protected virtual void pushData()
        {
            _Book.ISBN = long.Parse(txtISBN.Text);
            _Book.BookTitle = txtTitle.Text;
            _Book.BookType = char.Parse(txtType.Text);
            _Book.PricePerItem = decimal.Parse(txtPrice.Text);
            _Book.DateLastModified = DateTime.Parse(txtDate.Text);
            _Book.StockQuantity = int.Parse(txtQuantity.Text);
        }

        protected virtual bool IsValid()
        {
            bool lcResult = true;
            if (string.IsNullOrEmpty(txtISBN.Text))
            {
                _VaidationError.Add("ISBN can't be empty");
                lcResult = false;
            }
            if (string.IsNullOrEmpty(txtTitle.Text))
            {
                _VaidationError.Add("Title can't be empty");
                lcResult = false;
            }
            if (string.IsNullOrEmpty(txtType.Text))
            {
                _VaidationError.Add("Type can't be empty");
                lcResult = false;
            }
            if (string.IsNullOrEmpty(txtPrice.Text))
            {
                _VaidationError.Add("Price can't be empty");
                lcResult = false;
            } 
            if (string.IsNullOrEmpty(txtDate.Text))
            {
                _VaidationError.Add("Date can't be empty");
                lcResult = false;
            }
            if (string.IsNullOrEmpty(txtQuantity.Text))
            {
                _VaidationError.Add("Quantity can't be empty");
                lcResult = false;
            }

            return lcResult;

        }

        private async Task<bool> IsISBNTaken()
        {
            if (await ServiceClient.GetBookISBNAsync(_Book.ISBN) == 0)
                return false;
            else
            {
                _VaidationError.Add("Book ISBN is already taken");
                return true;
            }
        }
    }
}
