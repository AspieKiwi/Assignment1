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

        private clsPublisherList thePublisherList;
        private clsBooksList theBooksList;
        private byte sortOrder;

        private void UpdateDisplay()
        {
            txtName.Enabled = txtName.Text == "";
            if (sortOrder == 0)
            {
                theBooksList.SortByName();
                rbByName.Checked = true;
            }
            else
            {
                theBooksList.SortByDate();
                rbByDate.Checked = true;
            }

            lstBooks.DataSource = null;
            lstBooks.DataSource = theBooksList;
            lblTotal.Text = Convert.ToString(theBooksList.GetTotalValue());
        }

        public void SetDetails(string prName, string prCountry, byte prSortOrder, clsBooksList prBooksList, clsPublisherList prPublisherList)
        {
            txtName.Text = prName;
            txtCountry.Text = prCountry;
            theBooksList = prBooksList;
            thePublisherList = prPublisherList;
            sortOrder = prSortOrder;
            UpdateDisplay();
        }

        public void GetDetails(ref string prName, ref string prCountry, ref byte prSortOrder)
        {
            prName = txtName.Text;
            prCountry = txtCountry.Text;
            prSortOrder = sortOrder;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            theBooksList.DeleteBook(lstBooks.SelectedIndex);
            UpdateDisplay();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            theBooksList.AddBook();
            UpdateDisplay();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (isValid())
            {
                DialogResult = DialogResult.OK;
            }
        }

        public virtual Boolean isValid()
        {
            if (txtName.Enabled && txtName.Text != "")
                if (theBooksList.Contains(txtName.Text))
                {
                    MessageBox.Show("Publisher with that name already exists!");
                    return false;
                }
                else
                    return true;
            else
                return true;
        }
        private void lstBooks_DoubleClick(object sender, EventArgs e)
        {
            int lcIndex = lstBooks.SelectedIndex;
            if (lcIndex >= 0)
            {
                theBooksList.EditBook(lcIndex);
                UpdateDisplay();
            }
        }

        private void rByDate_CheckedChanged(object sender, EventArgs e)
        {
            sortOrder = Convert.ToByte(rbByDate.Checked);
            UpdateDisplay();
        }
    }
}
