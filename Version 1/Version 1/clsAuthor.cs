using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Version_1
{
    [Serializable()]
    public class clsAuthor
    {
        private string _Name;
        private string _Country;

        private clsBooksList _BooksList;
        private clsAuthorList _AuthorList;

        public clsAuthor() { }

        public clsAuthor(clsAuthorList prAuthorList)
        {
            _BooksList = new clsBooksList();
            _AuthorList = prAuthorList;
        }
        public bool IsDuplicate(string prAuthorList)
        {
            return _AuthorList.ContainsKey(prAuthorList);
        }

        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }

        public string Country
        {
            get { return _Country; }
            set { _Country = value; }
        }


        public decimal TotalValue
        {
            get { return _BooksList.GetTotalValue(); }
        }
        public clsAuthorList AuthorList
        {
            get { return _AuthorList; }
        }

        public clsBooksList BooksList
        {
            get { return _BooksList; }
        }
    }
}
