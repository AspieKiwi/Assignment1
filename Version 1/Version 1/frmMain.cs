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
        public frmMain()
        {
            InitializeComponent();
        }

        private clsPublisherList _PublisherList = new clsPublisherList();
        //private const string fileName = "books.xml";

        private void updateDisplay()
        {
            string[] lcDisplayList = new string[_PublisherList.Count];

            lstPublishers.DataSource = null;
            _PublisherList.Keys.CopyTo(lcDisplayList, 0);
            lstPublishers.DataSource = lcDisplayList;
            lblValue.Text = Convert.ToString(_PublisherList.GetTotalValue());
        }

        private void lstPublishers_DoubleClick(object sennder, EventArgs e)
        {
            string lcKey;

            lcKey = Convert.ToString(lstPublishers.SelectedItem);
            if(lcKey != null)
            {
                _PublisherList.EditPublisher(lcKey);
                updateDisplay();
            }
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            try
            {
                _PublisherList.Save();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "File Save Error");
            }
            Close();
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
            try
            {
                _PublisherList = clsPublisherList.RetrievePublisherList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Flie retrieve error");
            }
            updateDisplay();
            //Retrieve();
            //UpdateDisplay();
        }
    }

    

}
