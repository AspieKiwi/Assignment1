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
    public partial class frmCurrentOrders : Form
    {
        private clsOrder _Order;
        
        public frmCurrentOrders()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Hide();
        }

        private void frmCurrentOrders_Load(object sender, EventArgs e)
        {
            refreshFormFromDB();
        }

        private async void refreshFormFromDB()
        {
            try
            {
                UpdateDisplay(await ServiceClient.GetOrdersAsync());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Form could not be updated");
            }
        }

        public void UpdateDisplay(clsOrder prOrder)
        {
            _Order = prOrder;
            lstOrders.DataSource = null;
            if (_Order.OrderList != null)
                lstOrders.DataSource = _Order.OrderList;
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                int lcIndex = lstOrders.SelectedIndex;

                if (lcIndex >= 0 && MessageBox.Show("Are you sure?", "Deleting order", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    MessageBox.Show(await ServiceClient.DeleteOrderAsync(lstOrders.SelectedItem as clsOrder));
                    refreshFormFromDB();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
