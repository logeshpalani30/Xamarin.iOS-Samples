using Foundation;
using System;
using UIKit;
using Xamarin.SideMenu;

namespace SideMenu
{
    public partial class ViewController : UIViewController
    {
        private SideMenuManager sideMenuManager;
        public ViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.
            this.NavigationItem.SetLeftBarButtonItem(new UIBarButtonItem("Left Menu", UIBarButtonItemStyle.Plain, (sender, e) =>
            {
                PresentViewController(sideMenuManager.LeftNavigationController, true, null);
            }),
                false);

            this.NavigationItem.SetRightBarButtonItem(
                new UIBarButtonItem("Right Menu", UIBarButtonItemStyle.Plain, (sender, e) =>
                {
                    PresentViewController(sideMenuManager.RightNavigationController, true, null);
                }),
                false);
            sideMenuManager = new SideMenuManager();
            //var menu = new UISideMenuNavigationController(sideMenuManager, LeftSideViewController, true);
            //this.PresentViewController(menu, animated: true, null);
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}