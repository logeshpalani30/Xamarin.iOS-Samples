// WARNING
//
// This file has been generated automatically by Visual Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace ChildViewControlleriOSDemo
{
	[Register ("ViewController")]
	partial class ViewController
	{
		[Outlet]
		UIKit.UIButton btnBookings { get; set; }

		[Outlet]
		UIKit.UIButton btnStatistics { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (btnBookings != null) {
				btnBookings.Dispose ();
				btnBookings = null;
			}

			if (btnStatistics != null) {
				btnStatistics.Dispose ();
				btnStatistics = null;
			}
		}
	}
}
