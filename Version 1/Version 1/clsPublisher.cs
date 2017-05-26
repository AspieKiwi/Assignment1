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
        private string name;
        private string country;

        private decimal theTotalValue;

        private clsBooksList theBooksList;
        private clsPublisherList thePublisherList;

        private static frmPublisher publisherDialog = new frmPublisher();
        private byte sortOrder;

        public clsPublisher(clsPublisherList prPublisherList)
        {
            theBooksList = new clsBooksList();
            thePublisherList = prPublisherList;
            EditDetails();
        }

        public void EditDetails()
        {
            publisherDialog.SetDetails(name, country, sortOrder, theBooksList, thePublisherList);
            if (publisherDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                publisherDialog.GetDetails(ref name, ref country, ref sortOrder);
                theTotalValue = theBooksList.GetTotalValue();
            }
        }

        public string GetKey()
        {
            return name;
        }

        public decimal GetBooksValue()
        {
            return theTotalValue;
        }
    }
}
