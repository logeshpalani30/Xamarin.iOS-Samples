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

namespace ManageChildVC
{
    [Register ("ViewController")]
    partial class ViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UICollectionView collectionView { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIView ViewControllerSpace { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (collectionView != null) {
                collectionView.Dispose ();
                collectionView = null;
            }

            if (ViewControllerSpace != null) {
                ViewControllerSpace.Dispose ();
                ViewControllerSpace = null;
            }
        }
    }
}