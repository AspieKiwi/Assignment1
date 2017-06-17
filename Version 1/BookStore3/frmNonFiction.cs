using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace BookUniversal
{
    public partial class frmNonFiction : BookUniversal.frmBook
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

        //protected override bool IsValid()
        //{
        //    bool lcValid = true;
        //    if (!base.isValid())
        //        lcValid = false;
        //    if (!clsBookStoreUtility.CheckFloatValue(txtDewey.Text))
        //    {
        //        _ValidationErrors.Add("Dewey can only take numbers");
        //        lcValid = false;
        //    }
        //    return lcValid;
        //}
    }
}
