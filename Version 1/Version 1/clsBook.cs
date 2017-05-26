using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Version_1
{
    [Serializable()]
    public abstract class clsBook
    {
        protected string _Title;
        protected DateTime theDate = DateTime.Now;
        protected decimal theValue;
        protected decimal theQuantity;
        protected decimal thePageNumbers;

        public clsBook()
        {
            EditDetails();
        }

        public abstract void EditDetails();

        public static clsBook NewBook()
        {
            char lcReply;
            InputBox inputbox = new InputBox("Enter F for Fiction and N for Non-Fiction");
            //inputBox.ShowDialog();
            //if (inputBox.getAction() == true)
            if (inputbox.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                lcReply = Convert.ToChar(inputbox.getAnswer());

                switch (char.ToUpper(lcReply))
                {
                    case 'F': return new clsFiction();
                    case 'N': return new clsNonFiction();
                    default: return null;
                }
            }
            else
            {
                inputbox.Close();
                return null;
            }
        }
        public override string ToString()
        {
            return _Title + "\t" + theDate.ToShortDateString();
        }

        public string GetTitle()
        {
            return _Title;
        }

        public DateTime GetDate()
        {
            return theDate;
        }

        public decimal GetValue()
        {
            return theValue;
        }
    }
}