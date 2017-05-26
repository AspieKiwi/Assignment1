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
        private string theDewey;
        private string theType;

        [NonSerialized()]
        private static frmNonFiction nonFictionDialog;

        public override void EditDetails()
        {
            if (nonFictionDialog == null)
            {
                nonFictionDialog = new frmNonFiction();
            }
            nonFictionDialog.SetDetails(_Title, theDate, theValue, theQuantity, thePageNumbers);
            if(nonFictionDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                nonFictionDialog.GetDetails(ref _Title, ref theDate, ref theValue, ref theQuantity, ref thePageNumbers, ref theType, ref theDewey);
            }

        }
    }
}
