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
    public class clsBooksList : List<clsBook>
    {
        private static clsNameComparer _NameComparer = new clsNameComparer();
        private static clsDateComparer _DateComparer = new clsDateComparer();
        private byte _SortOrder;

        public void AddBook(char prChoice)
        {
            clsBook lcBook = clsBook.NewBook(prChoice);
            if (lcBook != null)
            {
                Add(lcBook);
            }
        }

        public void DeleteBook(int prIndex)
        {
            if (prIndex >= 0 && prIndex < this.Count)
            {
                clsBook lcBook = (clsBook)this[prIndex];
                lcBook.EditDetails();
                //if (MessageBox.Show("Are you sure?", "Deleting book", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                //{
                //    this.RemoveAt(prIndex);
                //}
            }
            else
                throw new Exception("Sorry no book selected #" + Convert.ToString(prIndex));
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
                lcTotal += lcBook.Value;
            }
            return lcTotal;
            //decimal lcTotal = 0;
            //foreach (clsBook lcBook in this)
            //{
            //    lcTotal += lcBook.GetValue();
            //}
            //return lcTotal;
        }

        public void SortByName()
        {
            Sort(_NameComparer);
            _SortOrder = 0;
        }

        public void SortByDate()
        {
            Sort(_DateComparer);
            _SortOrder = 1;
        }

        public byte SortOrder
        {
            get { return _SortOrder; }
            set { _SortOrder = value; }
        }
    }
}