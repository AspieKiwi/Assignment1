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
    // Name: Rebecca Stephens
    // Date: 19/06/17
    // Notes: This is the order page which sets the data in the boxes and then pushes the new data

    public sealed partial class pgOrder : Page
    {
        public delegate void LoadBookControlDelegate(clsAllBooks prBooks);
        private clsAllBooks _Book;
        private clsOrder _Order;

        public pgOrder()
        {
            this.InitializeComponent();
        }

        public void DispatchBookForm(clsAllBooks prBooks)
        {
            Dictionary<string, Delegate> _BookForm = new Dictionary<string, Delegate>
            {
                {"F", new LoadBookControlDelegate(RunFiction) },
                {"N", new LoadBookControlDelegate(RunNonFiction) }
            };
            _BookForm[prBooks.BookType.ToString()].DynamicInvoke(prBooks);
            UpdatePage(prBooks);
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            DispatchBookForm(e.Parameter as clsAllBooks);
        }

        protected override void OnNavigatingFrom(NavigatingCancelEventArgs e)
        {
            base.OnNavigatingFrom(e);
        }

        private void RunFiction(clsAllBooks prBook)
        {
           ctcBookDetails.Content = new ucFiction();
        }

        private void RunNonFiction(clsAllBooks prBook)
        {
            ctcBookDetails.Content = new ucNonFiction();
        }

        private void UpdatePage(clsAllBooks prBook)
        {
            _Book = prBook;
            txtISBN.Text = _Book.ISBN.ToString();
            txtTitle.Text = _Book.BookTitle;
            txtType.Text = _Book.BookType.ToString();
            txtStock.Text = _Book.StockQuantity.ToString();
            txtPrice.Text = _Book.PricePerItem.ToString();
            (ctcBookDetails.Content as IBookControl).UpdateControl(prBook);
        }

        private void PushData()
        {
            _Order = new clsOrder();
            _Order.TotalOrderCost = _Book.PricePerItem;
            _Order.CustomerName = txtName.Text;
            _Order.CustomerEmail = txtEmail.Text;
            _Order.OrderQuantity = int.Parse(txtQuantity.Text);
            _Order.BookISBN = _Book.ISBN;
            _Order.OrderDate = DateTime.Now;
        }

        private async void btnOrder_Click(object sender, RoutedEventArgs e)
        {
            cdOrderDialogue lcDialog = new cdOrderDialogue();
            var lcResult = await lcDialog.ShowAsync();
            if(lcResult  == ContentDialogResult.Primary)
            {
                if (IsValid())
                {
                    PushData();
                    try
                    {
                        await ServiceClient.UpdateBookAsync(_Book);
                        lcDialog.Content = await ServiceClient.InsertOrderAsync(_Order);
                        await lcDialog.ShowAsync();
                        Frame.GoBack();
                    }
                    catch (Exception ex)
                    {
                        lcDialog.Content = ex.Message;
                        lcDialog.SecondaryButtonText = "";
                        await lcDialog.ShowAsync();
                    }
                }
                else
                {
                    lcDialog.Content = "This form has errors";
                    lcDialog.SecondaryButtonText = "";
                    await lcDialog.ShowAsync();
                }
            }
        }


        private bool IsValid()
        {
            bool lcResult = true;
            if (string.IsNullOrEmpty(txtName.Text))
                lcResult = false;
            if (string.IsNullOrEmpty(txtEmail.Text))
                lcResult = false;
            if (string.IsNullOrEmpty(txtISBN.Text))
                lcResult = false;
            if (string.IsNullOrEmpty(txtPrice.Text))
                lcResult = false;
            if (string.IsNullOrEmpty(txtQuantity.Text))
                lcResult = false;
            if (string.IsNullOrEmpty(txtStock.Text))
                lcResult = false;
            if (string.IsNullOrEmpty(txtTitle.Text))
                lcResult = false;
            if (string.IsNullOrEmpty(txtType.Text))
                lcResult = false;
            return lcResult;
        }
    }
}
