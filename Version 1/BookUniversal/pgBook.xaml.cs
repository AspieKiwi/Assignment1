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
    public sealed partial class pgBook : Page
    {
        public pgBook()
        {
            this.InitializeComponent();
            _BookContent = new Dictionary<char, Delegate>
            {
                {'F', new LoadBookControlDelegate(RunFiction) },
                {'N', null }
            };
        }

        private clsAllBooks _Book;
        
        private void updatePage(clsAllBooks prBook)
        {
            _Book = prBook;
            txtISBN.Text = _Book.ISBN.ToString();
            txtTitle.Text = _Book.BookTitle;
            txtType.Text = _Book.BookType.ToString();
            txtPrice.Text = _Book.PricePerItem.ToString();
            txtQuantity.Text = _Book.StockQuantity.ToString();
            (ctcBookSpecs.Content as IBookControl).UpdateControl(prBook);
        }

        private void RunFiction(clsAllBooks prBook)
        {
            ctcBookSpecs.Content = new ucFiction();
            txbPageTitle.Text = "View Fiction";
        }

        private delegate void LoadBookControlDelegate(clsAllBooks prBook);
        private Dictionary<char, Delegate> _BookContent;
        private void dispatchBookContent(clsAllBooks prBook)
        {
            //_BookContent[prBook.BookType].DynamicInvoke(prBook);
            updatePage(prBook);
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            base.OnNavigatedFrom(e);
            dispatchBookContent(e.Parameter as clsAllBooks);
        }

    }
}
