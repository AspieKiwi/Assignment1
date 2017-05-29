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
    public partial class frmPublisher : Form
    {
        public frmPublisher()
        {
            InitializeComponent();
        }

        private clsPublisher _Publisher;
       // private clsPublisherList thePublisherList;
        private clsBooksList _BooksList;
        //private byte sortOrder;

        private void UpdateDisplay()
        {
            txtName.Enabled = txtName.Text == "";
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


        public void SetDetails(clsPublisher prPublisher)
        {
            _Publisher = prPublisher;
            updateForm();
            //txtName.Text = prName;
            //txtCountry.Text = prCountry;
            //theBooksList = prBooksList;
            //thePublisherList = prPublisherList;
            //sortOrder = prSortOrder;
            ShowDialog();
            UpdateDisplay();
        }

        private void updateForm()
        {
            txtName.Text = _Publisher.Name;
            txtCountry.Text = _Publisher.Country;
            _BooksList = _Publisher.BooksList;
        }

        private void pushData()
        {
            _Publisher.Name = txtName.Text;
            _Publisher.Country = txtCountry.Text;
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
                if (_Publisher.IsDuplicate(txtName.Text))
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
