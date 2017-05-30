using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;


namespace Version_1
{
     public sealed class clsDateComparer : IComparer<clsBook>
    {
        public static readonly clsDateComparer Instance = new clsDateComparer();

        private clsDateComparer() { }
        public int Compare(clsBook x, clsBook y)
        {
            clsBook lcBookX = x;
            clsBook lcBookY = y;
            DateTime lcDateX = lcBookX.Date.Date;
            DateTime lcDateY = lcBookY.Date.Date;

            return lcDateX.CompareTo(lcDateY);
        }
    }

    //class clsDDateComparer : IComparer<clsBook>
    //{
    //    public int Compare(clsBook x, clsBook y)
    //    {
    //        return y.Date.CompareTo(x.Date);
    //    }
    //}
}
