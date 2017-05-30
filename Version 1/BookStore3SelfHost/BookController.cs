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
    }
}
