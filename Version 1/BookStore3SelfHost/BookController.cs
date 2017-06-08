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
                DateLastModifed = Convert.ToDateTime(dr["DateLastModified"]),
                StockQuantity = Convert.ToInt32(dr["StockQuantity"]),
                BookDewey = dr["BookDewey"] is DBNull ? (float?)null : Convert.ToInt32(dr["BookDewey"]),
                BookLetterCode = dr["BookLetterCode"] is DBNull ? (string)null : Convert.ToString(dr["BookLetterCode"]),
                AuthorName = Convert.ToString(dr["AuthorName"])

            };
        }
    }
    }
