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
    public class clsBooksList : ArrayList
    {
        private static clsNameComparer theNameComparer = new clsNameComparer();
        private static clsDateComparer theDateComparer = new clsDateComparer();

        public void AddBook()
        {
            clsBook lcBook = clsBook.NewBook();
            if (lcBook != null)
            {
                Add(lcBook);
            }
        }

        public void DeleteBook(int prIndex)
        {
            if (prIndex >= 0 && prIndex < this.Count)
            {
                if (MessageBox.Show("Are you sure?", "Deleting book", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    this.RemoveAt(prIndex);
                }
            }
        }

        public void EditBook(int prIndex)
        {
            if (prIndex >= 0 && prIndex < this.Count)
            {
                clsBook lcBook = (clsBook)this[prIndex];
                lcBook.EditDetails();
            }
            else
            {
                MessageBox.Show("Sorry no book selected #" + Convert.ToString(prIndex));
            }
        }

        public decimal GetTotalValue()
        {
            decimal lcTotal = 0;
            foreach (clsBook lcBook in this)
            {
                lcTotal += lcBook.GetValue();
            }
            return lcTotal;
        }

        public void SortByName()
        {
            Sort(theNameComparer);
        }

        public void SortByDate()
        {
            Sort(theDateComparer);
        }
    }
}