using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Version_1
{
    public partial class frmFiction : Version_1.frmBook
    {
        public frmFiction()
        {
            InitializeComponent();
        }
        protected override void updateForm()
        {
            base.updateForm();
            clsFiction lcBook = (clsFiction)_Book;
            txt3letter.Text = lcBook.LetterCode;
            txtType.Text = lcBook.Type;
        }

        protected override void pushData()
        {
            base.pushData();
            clsFiction lcBook = (clsFiction)_Book;
            lcBook.LetterCode = txt3letter.Text;
            lcBook.Type = txtType.Text;
        }

        //public virtual void SetDetails(string prISBN, DateTime prDate, decimal prValue, decimal prQuantity, decimal prPageNumbers, string prType, string pr3Letter)
        //{
        //    base.SetDetails(prISBN, prDate, prValue, prQuantity, prPageNumbers);
        //    txt3letter.Text = pr3Letter;
        //    txtType.Text = prType;
        //}

        //public virtual void GetDetails(ref string prISBN, ref DateTime prDate, ref decimal prValue, ref decimal prQuantity, ref decimal prPageNumbers, ref string prType, ref string pr3Letter)
        //{
        //    base.GetDetails(ref prISBN, ref prDate, ref prValue, ref prQuantity, ref prPageNumbers);
        //    pr3Letter = txt3letter.Text;
        //    prType = txtType.Text;
        //}
    }
}
