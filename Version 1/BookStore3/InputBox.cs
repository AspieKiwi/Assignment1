using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookStoreWindows
{
    public partial class InputBox : Form
    {
        private string _Answer;
        public InputBox(string question)
        {
            InitializeComponent();
            lblQuestion.Text = question;
            lblError.Text = "";
            txtAnswer.Focus();
            ShowDialog();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            _Answer = txtAnswer.Text;
            DialogResult = DialogResult.OK;
        }
        public string Answer
        {
            get { return _Answer; } 
        }

        private void btnCancel_Click_1(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
