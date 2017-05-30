using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Version_1
{
    public partial class frmAuthor : Form
    {
        public frmAuthor()
        {
            InitializeComponent();
        }

        private clsAuthor _Author;
       // private clsPublisherList thePublisherList;
        private clsBooksList _BooksList;
        //private byte sortOrder;

        private static Dictionary<clsAuthor, frmAuthor> _AuthorFormList = new Dictionary<clsAuthor, frmAuthor>();

        public static void Run(clsAuthor prAuthor)
        {
            frmAuthor lcAuthorForm;
            if(!_AuthorFormList.TryGetValue(prAuthor, out lcAuthorForm))
            {
                lcAuthorForm = new frmAuthor();
                _AuthorFormList.Add(prAuthor, lcAuthorForm);
                lcAuthorForm.SetDetails(prAuthor);
            }
            else
            {
                lcAuthorForm.Show();
                lcAuthorForm.Activate();
            }
        }

        private void updateTitle(string prBookName)
        {
            if (!string.IsNullOrEmpty(prBookName))
                Text = "Author Details - " + prBookName;
        }
        private void UpdateDisplay()
        {
            //txtName.Enabled = txtName.Text == "";
            if (_BooksList.SortOrder == 0)
            {
                _BooksList.SortByName();
                rbByName.Checked = true;
            }
            else
            {
                _BooksList.SortByDate();
                rbByDate.Checked = true;
            }

            lstBooks.DataSource = null;
            lstBooks.DataSource = _BooksList;
            lblTotal.Text = Convert.ToString(_BooksList.GetTotalValue());
        }


        public void SetDetails(clsAuthor prAuthor)
        {
            _Author = prAuthor;
            txtName.Enabled = string.IsNullOrEmpty(_Author.Name);
            updateForm();
            UpdateDisplay();
            frmMain.Instance.BookNameChanged += new frmMain.Notify(updateTitle);
            updateTitle(_Author.AuthorList.BookName);
            Show();
            //txtName.Text = prName;
            //txtCountry.Text = prCountry;
            //theBooksList = prBooksList;
            //thePublisherList = prPublisherList;
            //sortOrder = prSortOrder;
            //ShowDialog();
            //UpdateDisplay();
        }

        private void updateForm()
        {
            txtName.Text = _Author.Name;
            txtCountry.Text = _Author.Country;
            _BooksList = _Author.BooksList;
        }

        private void pushData()
        {
            _Author.Name = txtName.Text;
            _Author.Country = txtCountry.Text;
        }

        //public void GetDetails(ref string prName, ref string prCountry, ref byte prSortOrder)
        //{
        //    prName = txtName.Text;
        //    prCountry = txtCountry.Text;
        //    prSortOrder = sortOrder;
        //}

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int lcIndex = lstBooks.SelectedIndex;

            if (lcIndex >= 0 && MessageBox.Show("Are you sure", "Deleting Book", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                _BooksList.RemoveAt(lcIndex);
                UpdateDisplay();
            }
            //theBooksList.DeleteBook(lstBooks.SelectedIndex);
            //UpdateDisplay();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string lcReply = new InputBox(clsBook.FACTORY_PROMPT).Answer;
            if (!string.IsNullOrEmpty(lcReply))
            {
                _BooksList.AddBook(lcReply[0]);
                UpdateDisplay();
                frmMain.Instance.updateDisplay();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (isValid() == true)
            {
                pushData();
                Close();
            }
        }

        public virtual Boolean isValid()
        {
            if (txtName.Enabled && txtName.Text != "")
                if (_Author.IsDuplicate(txtName.Text))
                {
                    MessageBox.Show("Publisher with that name already exsits!", "Error adding Publisher");
                    return false;
                }
                else
                    return true;
            else
                return true;
            //if (txtName.Enabled && txtName.Text != "")
            //    if (theBooksList.Contains(txtName.Text))
            //    {
            //        MessageBox.Show("Publisher with that name already exists!");
            //        return false;
            //    }
            //    else
            //        return true;
            //else
            //    return true;
        }
        private void lstBooks_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                _BooksList.EditBook(lstBooks.SelectedIndex);
                UpdateDisplay();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            //int lcIndex = lstBooks.SelectedIndex;
            //if (lcIndex >= 0)
            //{
            //    theBooksList.EditBook(lcIndex);
            //    UpdateDisplay();
            //}
        }

        private void rByDate_CheckedChanged(object sender, EventArgs e)
        {
            _BooksList.SortOrder = Convert.ToByte(rbByDate.Checked);
            UpdateDisplay();
            //sortOrder = Convert.ToByte(rbByDate.Checked);
            //UpdateDisplay();
        }
    }
}
