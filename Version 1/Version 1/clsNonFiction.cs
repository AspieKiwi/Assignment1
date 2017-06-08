using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore3
{
    [Serializable()]
   public class clsNonFiction : clsBook
    {
        private string _Dewey;
        private string _Type; // this disappears in the second version so where does it go?

        public delegate void LoadNonFictionFormDelegate(clsNonFiction prNonFiction);
        public static LoadNonFictionFormDelegate LoadNonFictionForm;
        public override void EditDetails()
        {
            LoadNonFictionForm(this);
        }

        public string Dewey
        {
            get { return _Dewey; }
            set { _Dewey = value; }
        }

        public string Type
        {
            get { return _Type; }
            set { _Type = value; }
        }
    }
}
