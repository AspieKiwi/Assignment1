using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Version_1
{
    [Serializable()]
   public class clsNonFiction : clsBook
    {
        private string _Dewey;
        private string _Type; // this disappears in the second version so where does it go?

        [NonSerialized()]
        private static frmNonFiction _nonFictionDialog;

        public override void EditDetails()
        {
            if (_nonFictionDialog == null)
                _nonFictionDialog = new frmNonFiction();
            _nonFictionDialog.SetDetails(this);
            //if (nonFictionDialog == null)
            //{
            //    nonFictionDialog = new frmNonFiction();
            //}
            //nonFictionDialog.SetDetails(_Title, theDate, theValue, theQuantity, thePageNumbers);
            //if(nonFictionDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            //{
            //    nonFictionDialog.GetDetails(ref _Title, ref theDate, ref theValue, ref theQuantity, ref thePageNumbers, ref theType, ref theDewey);
            //}

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
