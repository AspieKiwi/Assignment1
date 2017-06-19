using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace BookStoreWindows
{
    public partial class frmNonFiction : BookStoreWindows.frmBook
    {
        private static readonly frmNonFiction Instance = new frmNonFiction();
        public frmNonFiction()
        {
            InitializeComponent();
        }

        public static void Run(clsAllBooks prNonFiction)
        {
            Instance.SetDetails(prNonFiction);
        }

        protected override void updateForm()
        {
            base.updateForm();
            txtDewey.Text = _Book.BookDewey.ToString();

        }
    }
}
