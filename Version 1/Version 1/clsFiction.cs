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
        private string theLetterCode;
        private string theType;

        [NonSerialized()]
        private static frmFiction fictionDialog;

        public override void EditDetails()
        {
            if (fictionDialog == null)
            {
                fictionDialog = new frmFiction();
            }
            fictionDialog.SetDetails(_Title, theDate, theValue, theQuantity, thePageNumbers);
            if (fictionDialog.ShowDialog() == DialogResult.OK)
            {
                fictionDialog.GetDetails(ref _Title, ref theDate, ref theValue, ref theQuantity, ref thePageNumbers, ref theType, ref theLetterCode);
            }
        }
    }
}