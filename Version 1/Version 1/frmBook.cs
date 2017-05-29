﻿using System;
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
        protected clsBook _Book;
        public frmBook()
        {
            InitializeComponent();
        }

        public void SetDetails(clsBook prBook)//(string prISBN, DateTime prDate, decimal prValue, decimal prQuantity, decimal prPageNumbers)
        {
            _Book = prBook;
            updateForm();
            ShowDialog();
            //txtISBN.Text = prISBN;
            //txtDate.Text = prDate.ToShortDateString();
            //txtValue.Text = Convert.ToString(prValue);
            //txtQuantity.Text = Convert.ToString(prQuantity);
            //txtPageNumbers.Text = Convert.ToString(prPageNumbers);
        }

        //public void GetDetails(ref string prISBN, ref DateTime prDate, ref decimal prValue, ref decimal prQuantity, ref decimal prPageNumbers)
        //{
        //    prISBN = txtISBN.Text;
        //    prDate = Convert.ToDateTime(txtDate.Text);
        //    prValue = Convert.ToDecimal(txtValue.Text);
        //    prQuantity = Convert.ToDecimal(txtQuantity.Text);
        //    prPageNumbers = Convert.ToDecimal(txtPageNumbers.Text);
        //}

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (isValid())
            {
                pushData();
                Close();
            }
            //if (isValid() == true)
            //{
            //    DialogResult = DialogResult.OK;
            //    Close();
            //}
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            //DialogResult = DialogResult.Cancel;
            Close();
        }

        public virtual bool isValid()
        {
            return true;
        }

        protected virtual void updateForm()
        {
            txtISBN.Text = _Book.ISBN;
            txtTitle.Text = _Book.Title;
            txtDate.Text = _Book.Date.ToShortDateString();
            txtValue.Text = _Book.Value.ToString();
            txtQuantity.Text = _Book.Quantity.ToString();
            txtPageNumbers.Text = _Book.PageNumbers.ToString();
        }
        
        protected virtual void pushData()
        {
            _Book.ISBN = txtISBN.Text;
            _Book.Title = txtTitle.Text;
            _Book.Date = DateTime.Parse(txtDate.Text);
            _Book.Value = decimal.Parse(txtValue.Text);
            _Book.Quantity = decimal.Parse(txtQuantity.Text);
            _Book.PageNumbers = decimal.Parse(txtPageNumbers.Text);
        }
    }
}