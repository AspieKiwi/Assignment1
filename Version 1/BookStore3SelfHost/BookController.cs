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
                        Country = (string)lcResult.Rows[0]["AuthorCountry"]
                    };
            else
            return null;
                }
        }
    }
