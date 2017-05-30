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
    public partial class frmMain : Form
    {
        private static readonly frmMain _Instance = new frmMain();

        //private clsAuthorList _AuthorList = new clsAuthorList();

        public delegate void Notify(string prBookName);

        public event Notify BookNameChanged;
        public frmMain()
        {
            InitializeComponent();
        }

        public static frmMain Instance
        {
            get { return frmMain._Instance; }
        }

        private void updateTitle(string prBookName)
        {
            if (!string.IsNullOrEmpty(prBookName))
                Text = "Book Storage (v1) - " + prBookName;
        }

        //private clsPublisherList _PublisherList = new clsPublisherList();
        //private const string fileName = "books.xml";

        //public async void updateDisplay()
        //{
        //    lstAuthors.DataSource = null;
        //    //lstAuthors.DataSource = await ServiceClient.GetAuthorNamesAsync();
        //   // string[] lcDisplayList = new string[_AuthorList.Count];
        //    //_AuthorList.Keys.CopyTo(lcDisplayList, 0);
        //   // lstAuthors.DataSource = lcDisplayList;
        //    //lblValue.Text = Convert.ToString(_AuthorList.GetTotalValue());
        //    //string[] lcDisplayList = new string[_PublisherList.Count];

        //    //lstPublishers.DataSource = null;
        //    //_PublisherList.Keys.CopyTo(lcDisplayList, 0);
        //    //lstPublishers.DataSource = lcDisplayList;
        //    //lblValue.Text = Convert.ToString(_PublisherList.GetTotalValue());
        //}

        private void lstAuthors_DoubleClick(object sennder, EventArgs e)
        {
            string lcKey;

            lcKey = Convert.ToString(lstAuthors.SelectedItem);
            if(lcKey != null)
            {
                try
                {
                    frmAuthor.Run(lstAuthors.SelectedItem as string);
                    //frmAuthor.Run(_AuthorList[lcKey]);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "This should never occur");
                }
            }
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    //_AuthorList.Save();
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message, "File Save Error");
            //}
            //Close();
            //Save();
            //Close();
        }

        //private void Save()
        //{
        //    try
        //    {
        //        System.IO.FileStream lcFileStream = new System.IO.FileStream(fileName, System.IO.FileMode.Open);
        //        System.Runtime.Serialization.Formatters.Soap.SoapFormatter lcFormatter =
        //            new System.Runtime.Serialization.Formatters.Soap.SoapFormatter();

        //        lcFormatter.Serialize(lcFileStream, thePublisherList);
        //        lcFileStream.Close();
        //    }
        //    catch (Exception e)
        //    {
        //        MessageBox.Show(e.Message, "File Save Error");
        //    }
        //}
        //private void Retrieve()
        //{
        //    try
        //    {
        //        System.IO.FileStream lcFileStream = new System.IO.FileStream(fileName, System.IO.FileMode.Open);
        //        System.Runtime.Serialization.Formatters.Soap.SoapFormatter lcFormatter =
        //            new System.Runtime.Serialization.Formatters.Soap.SoapFormatter();
        //    }
        //    catch (Exception e)
        //    {
        //        MessageBox.Show(e.Message, "File Retrieve Error");
        //    }
        //}
        private void frmMain_Load(object sender, EventArgs e)
        {
            //try
            //{
            //    //_AuthorList = clsAuthorList.RetrieveAuthorList();
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message, "Flie retrieve error");
            //}
            //updateDisplay();
            //BookNameChanged += new Notify(updateTitle);
            //BookNameChanged(_AuthorList.BookName);
            //Retrieve();
            //UpdateDisplay();
        }
    }

    

}
