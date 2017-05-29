using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Version_1
{
    [Serializable()]
    public class clsPublisher
    {
        private string _Name;
        private string _Country;

        private decimal _TotalValue;

        private clsBooksList _BooksList;
        private clsPublisherList _PublisherList;

        private static frmPublisher _PublisherDialog = new frmPublisher();
        //private byte sortOrder;

        public clsPublisher() { }

        public clsPublisher(clsPublisherList prPublisherList)
        {
            _BooksList = new clsBooksList();
            _PublisherList = prPublisherList;
            EditDetails();
        }

        public void EditDetails()
        {
            _PublisherDialog.SetDetails(this);
            _TotalValue = _BooksList.GetTotalValue();
            //publisherDialog.SetDetails(name, country, sortOrder, theBooksList, thePublisherList);
            //if (publisherDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            //{
            //    publisherDialog.GetDetails(ref name, ref country, ref sortOrder);
            //    theTotalValue = theBooksList.GetTotalValue();
            //}
        }

        public bool IsDuplicate(string prPublisherName)
        {
            return _PublisherList.ContainsKey(prPublisherName);
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

        //public string GetKey()
        //{
        //    return name;
        //}

        public decimal TotalValue
        {
            get { return _TotalValue; }
        }

        public clsBooksList BooksList
        {
            get { return _BooksList; }
        }
    }
}
