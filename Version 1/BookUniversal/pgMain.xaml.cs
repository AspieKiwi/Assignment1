using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;



namespace BookStoreUniversal
{
    // Author: Rebecca Stephens
    // Date: 19/06/17
    // Notes: This is the main page for the UWP app
    public sealed partial class pgMain : Page
    {
        public pgMain()
        {
            this.InitializeComponent();
        }

        private async void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                lstAuthors.ItemsSource = await ServiceClient.GetAuthorNamesAsync();
            }
            catch (Exception ex)
            {
                txbMessage.Text = ex.GetBaseException().Message;
            }
        }

        private void viewAuthor()
        {
            if (lstAuthors.SelectedItem != null)
                Frame.Navigate(typeof(pgAuthor), lstAuthors.SelectedIndex);
        }

        private void btnView_Click(object sender, RoutedEventArgs e)
        {
           Frame.Navigate(typeof(pgAuthor), (string)lstAuthors.SelectedValue);
        }
    }
}
