using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookUniversal
{
    interface IBookControl
    {
        void PushData(clsAllBooks prBook);
        void UpdateControl(clsAllBooks prBook);
    }
}
