using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using System.Collections;

namespace BookStore
{
    sealed class clsNameComparer : IComparer<clsBook>
    {
        public static readonly clsNameComparer Instance = new clsNameComparer();

        private clsNameComparer() { }
        public int Compare(clsBook x, clsBook y)
        {
            clsBook bookClassX = x;
            clsBook bookClassY = y;
            string lcNameX = bookClassX.Title;
            string lcNameY = bookClassY.Title;

            return lcNameX.CompareTo(lcNameY);
        }
    }
}
