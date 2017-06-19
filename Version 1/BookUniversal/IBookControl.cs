using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreUniversal
    // Author: Rebecca Stephens
    // Date: 19/09/17

{
    interface IBookControl
    {
        void UpdateControl(clsAllBooks prBook);

        void PushData(clsAllBooks prBook);
    }
}
