using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;

namespace Version_1
{
    [Serializable()]
    public class clsPublisherList : SortedList
    {
        public void EditPublisher(string prKey)
        {
            clsPublisher lcPublisher;
            lcPublisher = (clsPublisher)this[prKey];
            if (lcPublisher != null)
                lcPublisher.EditDetails();
            else
                MessageBox.Show("Sorry no publisher by this name");
        }
        public decimal GetTotalValue()
        {
            decimal lcTotal = 0;
            foreach (clsPublisher lcPublisher in Values)
            {
                lcTotal += lcPublisher.GetBooksValue();
            }
            return lcTotal;
        }
    }
}
