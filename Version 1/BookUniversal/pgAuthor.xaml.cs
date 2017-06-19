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
    //Author: Rebecca Stephens
    // Date: 18/06/2017
    // Notes: This page displays the details associated with a particular author.
    public sealed partial class pgAuthor : Page
    {
        private clsAuthor _Author;
        public pgAuthor()
        {
            this.InitializeComponent();
        }
        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            try
            {
                base.OnNavigatedTo(e);
                if (e.Parameter != null)
                {
                    string lcAuthorName = e.Parameter.ToString();
                    _Author = await ServiceClient.GetAuthorAsync(lcAuthorName);
                    UpdateDisplay();
                }
                else
                    _Author = new clsAuthor();
            }
            catch (Exception ex)
            {

                txbMessage.Text = ex.GetBaseException().Message;
            }
        }

        protected override void OnNavigatingFrom(NavigatingCancelEventArgs e)
        {
            base.OnNavigatingFrom(e);
        }


        private void UpdateDisplay()
        {
           txbName.Text = _Author.Name;
           txbCountry.Text = _Author.Country;
            lstBoxBooks.ItemsSource = _Author.BooksList.ToList();
        }

        private void btnOrder_Click(object sender, RoutedEventArgs e)
        {

        }

        private void lstBoxBooks_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Frame.Navigate(typeof(pgOrder), (clsAllBooks)lstBoxBooks.SelectedValue);
        }

        //private void editBook(clsAllBooks prBook)
        //{
        //    if (prBook != null)
        //        Frame.Navigate(typeof(pgOrder), prBook);
        //}
    }
}
