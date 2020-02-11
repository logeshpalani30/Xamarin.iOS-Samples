// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace chartsDemo
{
    [Register ("ViewController")]
    partial class ViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        OxyPlot.Xamarin.iOS.PlotView plotview { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (plotview != null) {
                plotview.Dispose ();
                plotview = null;
            }
        }
    }
}