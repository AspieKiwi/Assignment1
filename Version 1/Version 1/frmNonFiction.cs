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
        public frmNonFiction()
        {
            InitializeComponent();
        }

        protected override void updateForm()
        {
            base.updateForm();
            clsNonFiction lcBook = (clsNonFiction)_Book;
            txtDewey.Text = lcBook.Dewey;
            txtType.Text = lcBook.Type;
        }

        protected override void pushData()
        {
            base.pushData();
            clsNonFiction lcBook = (clsNonFiction)_Book;
            lcBook.Dewey = txtDewey.Text;
            lcBook.Type = txtType.Text;
        }

        //public void SetDetails(string prISBN, DateTime prDate, decimal prValue, decimal prQuantity, decimal prPageNumbers, string prDewey, string prType)
        //{
        //    base.SetDetails(prISBN, prDate, prValue, prQuantity, prPageNumbers);
        //    txtDewey.Text = prDewey;
        //    txtType.Text = prType;
        //}

        //public virtual void GetDetails(ref string prISBN, ref DateTime prDate, ref decimal prValue, ref decimal prQuantity, ref decimal prPageNumbers, ref string prType, ref string prDewey)
        //{
        //    base.GetDetails(ref prISBN, ref prDate, ref prValue, ref prQuantity, ref prPageNumbers);
        //    prDewey = txtDewey.Text;
        //    prType = txtType.Text;
        //}
    }
}
