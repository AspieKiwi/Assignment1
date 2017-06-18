using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace BookStoreWindows
{
    public partial class frmFiction : BookStoreWindows.frmBook
    {
        private static readonly frmFiction Instance = new frmFiction();
        public frmFiction()
        {
            InitializeComponent();
        }

        public static void Run(clsAllBooks prFiction)
        {
            Instance.SetDetails(prFiction);
        }

        protected override void updateForm()
        {
            base.updateForm();
            txtLetterCode.Text = _Book.BookLetterCode;
        }

        protected override void pushData()
        {
            base.pushData();
            _Book.BookLetterCode = txtLetterCode.Text;
        }

    }
}
