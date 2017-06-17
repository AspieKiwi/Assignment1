using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore3SelfHost
{
    public class clsAuthor
    {
        public string Name { get; set; }
        public string Country { get; set; }

        public List<clsAllBooks> BooksList { get; set; }
    }

    public class clsAllBooks
    {
        public long ISBN { get; set; }
        public string BookTitle { get; set; }
        public char BookType { get; set; }
        public decimal PricePerItem { get; set; }
        public DateTime DateLastModified { get; set; }
        public int StockQuantity { get; set; }
        public float? BookDewey { get; set; }
        public string BookLetterCode { get; set; }
        public string AuthorName { get; set; }
    }

    public class clsOrder
    {
        public int OrderID { get; set; }
        public string CustomerName { get; set; }
        public string CustomerEmail { get; set; }
        public decimal TotalOrderCost { get; set; }
        public float OrderQuantity { get; set; }
        public DateTime OrderDate { get; set; }
        public long BookISBN { get; set; }

    }
}
