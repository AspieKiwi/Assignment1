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
    public partial class frmMain : Form
    {
        private static readonly frmMain _Instance = new frmMain();

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

        public async void updateDisplay()
        {
            try
            {
                lstAuthors.DataSource = null;
                lstAuthors.DataSource = await ServiceClient.GetAuthorNamesAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n" + ex.StackTrace);
            }
        }


        private void btnQuit_Click(object sender, EventArgs e)
        {
            Close();
        }

        
        private void frmMain_Load(object sender, EventArgs e)
        {
            
        }

        private void frmMain_Load_1(object sender, EventArgs e)
        {
            updateDisplay();
        }

        private void lstAuthors_DoubleClick(object sender, EventArgs e)
        {
            string lcKey;

            lcKey = Convert.ToString(lstAuthors.SelectedItem);
            if (lcKey != null)
            {
                try
                {
                    frmAuthor.Run(lstAuthors.SelectedItem as string);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "This should never occur");
                }
            }
        }

        private void btnOrder_Click(object sender, EventArgs e)
        {
            frmCurrentOrders lcCurrentOrder;
            lcCurrentOrder = new frmCurrentOrders();
            lcCurrentOrder.Show();
        }
    }

    

}
