using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Version_1
{
    [Serializable()]
    class clsFiction : clsBook
    {
        private string _LetterCode;
        private string _Type;

        [NonSerialized()]
        private static frmFiction _FictionDialog;

        public override void EditDetails()
        {
            if (_FictionDialog == null)
                _FictionDialog = new frmFiction();
            _FictionDialog.SetDetails(this);
            //if (fictionDialog == null)
            //{
            //    fictionDialog = new frmFiction();
            //}
            //fictionDialog.SetDetails(_Title, theDate, theValue, theQuantity, thePageNumbers);
            //if (fictionDialog.ShowDialog() == DialogResult.OK)
            //{
            //    fictionDialog.GetDetails(ref _Title, ref theDate, ref theValue, ref theQuantity, ref thePageNumbers, ref theType, ref theLetterCode);
            //}
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