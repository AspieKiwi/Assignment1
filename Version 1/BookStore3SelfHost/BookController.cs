using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace BookStore3SelfHost
{
    public class BookController : System.Web.Http.ApiController
    {
        public List<string> GetAuthorNames()
        {

            DataTable lcResult = clsDbConnection.GetDataTable("SELECT AuthorName FROM Author", null);
            List<string> lcNames = new List<string>();
            foreach (DataRow dr in lcResult.Rows)
                lcNames.Add((string)dr[0]);
            return lcNames;
        }
        public List<clsAuthor> GetAuthors()
        {

            DataTable lcResult = clsDbConnection.GetDataTable("SELECT * FROM Author", null);
            List<clsAuthor> lcAuthor = new List<clsAuthor>();
            foreach (DataRow dr in lcResult.Rows)
            {
                lcAuthor.Add(new clsAuthor()
                {
                    
                    //ID = (int)dr["AuthorID"],
                    Name = (string)dr["AuthorName"],
                    Country = (string)dr["AuthorCountry"]
                });
            }
        //        lcNames.Add((clsAuthor)dr[0]);
            return lcAuthor;
        }

        public clsAuthor GetAuthor(string Name)
        {
            Dictionary<string, object> par = new Dictionary<string, object>(1);
            par.Add("Name", Name);
            DataTable lcResult =
                clsDbConnection.GetDataTable("SELECT * FROM Author WHERE AuthorName = @Name", par);
            if(lcResult.Rows.Count > 0)
                    return new clsAuthor()
                    {
                        Name = (string)lcResult.Rows[0]["AuthorName"],
                        Country = (string)lcResult.Rows[0]["AuthorCountry"],
                        BooksList = getAuthorsBooks(Name)
                    };
            else
            return null;
                }

        private List<clsAllBooks> getAuthorsBooks(string Name)
        {
            Dictionary<string, object> par = new Dictionary<string, object>(1);
            par.Add("Name", Name);
            DataTable lcResult = clsDbConnection.GetDataTable("SELECT * FROM Book WHERE AuthorName = @Name", par);
            List<clsAllBooks> lcBooks = new List<clsAllBooks>();
            foreach (DataRow dr in lcResult.Rows)
                lcBooks.Add(dataRow2AllBook(dr));
            return lcBooks;
        }

        private clsAllBooks dataRow2AllBook(DataRow dr)
        {
            return new clsAllBooks()
            {
                ISBN = Convert.ToInt64(dr["ISBN"]),
                BookTitle = Convert.ToString(dr["BookTitle"]),
                BookType = Convert.ToChar(dr["BookType"]),
                PricePerItem = Convert.ToDecimal(dr["PricePerItem"]),
                DateLastModified = Convert.ToDateTime(dr["DateLastModified"]),
                StockQuantity = Convert.ToInt32(dr["StockQuantity"]),
                BookDewey = dr["BookDewey"] is DBNull ? (float?)null : Convert.ToInt32(dr["BookDewey"]),
                BookLetterCode = dr["BookLetterCode"] is DBNull ? (string)null : Convert.ToString(dr["BookLetterCode"]),
                AuthorName = Convert.ToString(dr["AuthorName"])

            };


        }

        private Dictionary<string, object> prepareBookParameters(clsAllBooks prBook)
        {
            Dictionary<string, object> par = new Dictionary<string, object>(10);
            par.Add("BookType", prBook.BookType);
            par.Add("ISBN", prBook.ISBN);
            par.Add("BookTitle", prBook.BookTitle);
            par.Add("PricePerItem", prBook.PricePerItem);
            par.Add("StockQuantity", prBook.StockQuantity);
            par.Add("BookDewey", prBook.BookDewey);
            par.Add("BookLetterCode", prBook.BookLetterCode);
            par.Add("DateLastModified", prBook.DateLastModified);
            par.Add("AuthorName", prBook.AuthorName);
            return par;

        }

        private Dictionary<string, object> prepareBookDeletionParameters(string prBookName, string prAuthorName)
        {
            Dictionary<string, object> par = new Dictionary<string, object>(2);
            par.Add("BookTitle", prBookName);
            par.Add("AuthorName", prAuthorName);
            return par;
        }

        public string DeleteBook(string BookTitle, string AuthorName)
        {
            try
            {
                int lcRecCount = clsDbConnection.Execute(
                    "DELETE FROM Book WHERE BookTitle = @BookTitle AND AuthorName = @AuthorName", prepareBookDeletionParameters(BookTitle, AuthorName));
                if (lcRecCount == 1)
                    return "One Book Deleted";
                else
                    return "Unexpected book deletion count: " + lcRecCount;
            }
            catch (Exception ex)
            {
                return ex.GetBaseException().Message;
            }
        }

        public string PostBook(clsAllBooks prBook)
        {
            try
            {
                int lcRecCount = clsDbConnection.Execute("INSERT INTO Book " +
                    "(BookType, ISBN, BookTitle, PricePerItem, DateLastModified, StockQuantity, BookDewey, BookLetterCode, AuthorName) " +
                    "VALUES (@BookType, @ISBN, @BookTitle, @PricePerItem, @DateLastModified, @StockQuantity, @BookDewey, @BookLetterCode, @AuthorName)",
                    prepareBookParameters(prBook));
                if (lcRecCount == 1)
                    return "One Book Inserted";
                else
                    return "Unexpected author insert count: " + lcRecCount;

            }
            catch (Exception ex)
            {
                return ex.GetBaseException().Message;
            }

        }

        public string PutBook(clsAllBooks prBook)
        {
            try
            {
                int lcRecCount = clsDbConnection.Execute("UPDATE Book SET BookType = @BookType, ISBN = @ISBN, BookTitle = @BookTitle, PricePerItem = @PricePerItem, DateLastModified = @DateLastModified, StockQuantity = @StockQuantity, BookDewey = @BookDewey, BookLetterCode = @BookLetterCode, AuthorName = @AuthorName WHERE BookTitle = @BookTitle",
                    prepareBookParameters(prBook));
                if (lcRecCount == 1)
                    return "One Book Updated";
                else
                    return "Unexpected book update count: " + lcRecCount;
            }
            catch (Exception ex)
            {
                return ex.GetBaseException().Message;
            }
        }

        //public List<clsOrder> GetOrderList()
        //{
        //    DataTable lcResult = clsDbConnection.GetDataTable("SELECT Book.BookTitle, Order.* FROM Book JOIN Order " + "ON Book.ISBN = Order.BookISBN", null);
        //    List<clsOrder> lcOrder = new List<clsOrder>();
        //    foreach (DataRow dr in lcResult.Rows)
        //        lcOrder.Add(dataRowOrder(dr));
        //    return lcOrder;
        //}

        public string PostOrder(clsOrder prOrder)
        {
            try
            {
                int lcRecCount = clsDbConnection.Execute("INSERT INTO [Order]" 
                    + "(CustomerName, CustomerEmail, TotalOrderCost, OrderQuantity, OrderDate, BookISBN)" +
                    "VALUES (@CustomerName, @CustomerEmail, @TotalOrderCost, @OrderQuantity, @OrderDate, @BookISBN)",
                    prepareOrderParameters(prOrder));
                if (lcRecCount == 1)
                    return "Order Complete";
                else
                    return "Unexpected order post count: " + lcRecCount;
            }
            catch (Exception ex)
            {
                return ex.GetBaseException().Message;
            }
        }

        private Dictionary<string, object> prepareOrderParameters(clsOrder prOrder)
        {
            Dictionary<string, object> par = new Dictionary<string, object>(11);
            par.Add("OrderID", prOrder.OrderID);
            par.Add("CustomerName", prOrder.CustomerName);
            par.Add("CustomerEmail", prOrder.CustomerEmail);
            par.Add("TotalOrderCost", prOrder.TotalOrderCost);
            par.Add("OrderQuantity", prOrder.OrderQuantity);
            par.Add("OrderDate", prOrder.OrderDate);
            par.Add("BookISBN", prOrder.BookISBN);
            return par;
        }
    }
}
