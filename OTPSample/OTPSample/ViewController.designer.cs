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

namespace OTPSample
{
    [Register ("ViewController")]
    partial class ViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField fieldFour { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField fieldOne { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField fieldThree { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField fieldTwo { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (fieldFour != null) {
                fieldFour.Dispose ();
                fieldFour = null;
            }

            if (fieldOne != null) {
                fieldOne.Dispose ();
                fieldOne = null;
            }

            if (fieldThree != null) {
                fieldThree.Dispose ();
                fieldThree = null;
            }

            if (fieldTwo != null) {
                fieldTwo.Dispose ();
                fieldTwo = null;
            }
        }
    }
}