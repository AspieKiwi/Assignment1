using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore3
{

    public class clsAuthor
    {
        public string Name { get; set; }
        public string Country { get; set; }

        public List<clsAllBooks> BooksList { get; set; }
        public override string ToString()
        {
            return Name;
        }
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

        public override string ToString()
        {
            return BookTitle + "\t" + DateLastModified.ToShortDateString();
        }

        public static readonly string FACTORY_PROMPT = "Enter F for Fiction and N for Non-Fiction";

        public static clsAllBooks NewBook(char prChoice)
        {
            return new clsAllBooks() { BookType = Char.ToUpper(prChoice) };
            //switch (char.ToUpper(prChoice))
            //{
            //    case 'F': return new clsAllBooks { BookType = 'F' };
            //    case 'N': return new clsAllBooks { BookType = 'N' };
            //    default: return null;
            //}
        }
    }
}
