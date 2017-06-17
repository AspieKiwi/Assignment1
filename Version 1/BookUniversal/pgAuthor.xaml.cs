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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace BookUniversal
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class pgAuthor : Page
    {
        public pgAuthor()
        {
            this.InitializeComponent();
        }

        private clsAuthor _Author;

        protected async override void OnNavigatedTo(NavigationEventArgs e)
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

        protected override void OnNavigatingFrom(NavigatingCancelEventArgs e)
        {
            base.OnNavigatingFrom(e);
        }

        private async void UpdatePage(string prAuthorName)
        {
            try
            {
                SetDetails(await ServiceClient.GetAuthorAsync(prAuthorName));
            }
            catch (Exception ex)
            {
                txbMessage.Text = ex.Message;
            }
        }

        private void SetDetails(clsAuthor prAuthor)
        {
            _Author = prAuthor;
            UpdateDisplay();
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
    }
}
