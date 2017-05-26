using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Version_1
{
    class clsNameComparer : IComparer
    {
        public int Compare(Object x, Object y)
        {
            clsBook bookClassX = (clsBook)x;
            clsBook bookClassY = (clsBook)y;
            string lcNameX = bookClassX.GetTitle();
            string lcNameY = bookClassY.GetTitle();

            return lcNameX.CompareTo(lcNameY);
        }
    }
}
