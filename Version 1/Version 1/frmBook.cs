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
    public partial class frmBook : Form
    {
        public frmBook()
        {
            InitializeComponent();
        }

        public void SetDetails(string prISBN, DateTime prDate, decimal prValue, decimal prQuantity, decimal prPageNumbers)
        {
            txtISBN.Text = prISBN;
            txtDate.Text = prDate.ToShortDateString();
            txtValue.Text = Convert.ToString(prValue);
            txtQuantity.Text = Convert.ToString(prQuantity);
            txtPageNumbers.Text = Convert.ToString(prPageNumbers);
        }

        public void GetDetails(ref string prISBN, ref DateTime prDate, ref decimal prValue, ref decimal prQuantity, ref decimal prPageNumbers)
        {
            prISBN = txtISBN.Text;
            prDate = Convert.ToDateTime(txtDate.Text);
            prValue = Convert.ToDecimal(txtValue.Text);
            prQuantity = Convert.ToDecimal(txtQuantity.Text);
            prPageNumbers = Convert.ToDecimal(txtPageNumbers.Text);
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (isValid() == true)
            {
                DialogResult = DialogResult.OK;
                Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        public virtual bool isValid()
        {
            return true;
        }
    }
}
