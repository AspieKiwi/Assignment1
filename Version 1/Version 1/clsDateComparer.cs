using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;


namespace Version_1
{
    class clsDateComparer : IComparer<clsBook>
    {
        public int Compare(clsBook x, clsBook y)
        {
            //clsBook lcBookX = (clsBook)x;
            //clsBook lcBookY = (clsBook)y;
            //DateTime lcDateX = lcBookX.GetDate();
            //DateTime lcDateY = lcBookY.GetDate();

            return x.Date.CompareTo(y.Date);
        }
    }

    class clsDDateComparer : IComparer<clsBook>
    {
        public int Compare(clsBook x, clsBook y)
        {
            return y.Date.CompareTo(x.Date);
        }
    }
}
