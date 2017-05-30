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
        protected string _ISBN;
        protected string _Title;
        protected decimal _PricePerItem;
        protected DateTime _Date = DateTime.Now;
        protected decimal _Quantity;
        public static readonly string FACTORY_PROMPT = "Enter F for Fiction and N for NonFiction";

        public clsBook()
        {
            EditDetails();
        }

        public abstract void EditDetails();

        public static clsBook NewBook(char prChoice)
        {
            switch (char.ToUpper(prChoice))
            {
                case 'F': return new clsFiction();
                case 'N': return new clsNonFiction();
                default: return null;
            }
            //char lcReply;
            //InputBox inputbox = new InputBox("Enter F for Fiction and N for Non-Fiction");
            ////inputBox.ShowDialog();
            ////if (inputBox.getAction() == true)
            //if (inputbox.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            //{
            //    lcReply = Convert.ToChar(inputbox.getAnswer());

            //    switch (char.ToUpper(lcReply))
            //    {
            //        case 'F': return new clsFiction();
            //        case 'N': return new clsNonFiction();
            //        default: return null;
            //    }
            //}
            //else
            //{
            //    inputbox.Close();
            //    return null;
            //}
        }
        public override string ToString()
        {
            return _Title + "\t" + _Date.ToShortDateString();
        }

        public string Title
        {
            get { return _Title; }
            set { _Title = value; }
        }

        public string ISBN
        {
            get { return _ISBN; }
            set { _ISBN = value; }
        }



        public decimal PricePerItem
        {
            get { return _PricePerItem; }
            set { _PricePerItem = value;  }
        }

        public DateTime Date
        {
            get { return _Date; }
            set { _Date = value; }
        }

        public decimal Quantity
        {
            get { return _Quantity; }
            set { _Quantity = value; }
        }


    }
}