using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;



namespace BookStoreUniversal
{
    //Author: Rebecca Stephens
    //Date: 19/06/17
    //Note: user control for fiction type books. Doesn't current work
    public sealed partial class ucNonFiction : UserControl, IBookControl
    {
        public ucNonFiction()
        {
            this.InitializeComponent();
        }

        public void PushData(clsAllBooks prBook)
        {
            throw new NotImplementedException();
        }

        public void UpdateControl(clsAllBooks prBook)
        {
            throw new NotImplementedException();
        }
    }
}
