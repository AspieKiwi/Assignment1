using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;


namespace Version_1
{
    class clsDateComparer : IComparer
    {
        public int Compare(Object x, Object y)
        {
            clsBook lcBookX = (clsBook)x;
            clsBook lcBookY = (clsBook)y;
            DateTime lcDateX = lcBookX.GetDate();
            DateTime lcDateY = lcBookY.GetDate();

            return lcDateX.CompareTo(lcDateY);
        }
    }
}
