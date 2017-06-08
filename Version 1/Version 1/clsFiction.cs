using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookStore3
{
    [Serializable()]
    public class clsFiction : clsBook
    {
        private string _LetterCode;
        private string _Type;

        public delegate void LoadFictionFormDelegate(clsFiction prFiction);
        public static LoadFictionFormDelegate LoadFictionForm;


        public override void EditDetails()
        {
            LoadFictionForm(this);
        }
        public string LetterCode
        {
            get { return _LetterCode; }
            set { _LetterCode = value; }
        }

        public string Type
        {
            get { return _Type; }
            set { _Type = value; }
        }
    }
}