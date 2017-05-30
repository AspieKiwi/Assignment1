using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Version_1
{
    public partial class frmNonFiction : Version_1.frmBook
    {
        public static readonly frmNonFiction Instance = new frmNonFiction();
        public frmNonFiction()
        {
            InitializeComponent();
        }

        public static void Run(clsNonFiction prNonFiction)
        {
            Instance.SetDetails(prNonFiction);
        }

        protected override void updateForm()
        {
            base.updateForm();
            clsNonFiction lcBook = (clsNonFiction)this._Book;
            txtDewey.Text = lcBook.Dewey;
        }

        protected override void pushData()
        {
            base.pushData();
            clsNonFiction lcBook = (clsNonFiction)_Book;
            lcBook.Dewey = txtDewey.Text;
        }
    }
}
