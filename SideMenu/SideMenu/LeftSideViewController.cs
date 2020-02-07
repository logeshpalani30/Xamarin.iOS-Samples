using System;
using UIKit;
using Xamarin.SideMenu;

namespace SideMenu
{
    public partial class LeftSideViewController : UIViewController
    {
        private SideMenuManager sideMenuManager;
        private UIViewController leftSideController;
        private UIViewController rightSideController;

        public LeftSideViewController(IntPtr handle) : base(handle)
        {
        }
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

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

            SetupSideMenu();
            SetDefaults();
        }
        void SetupSideMenu()
        {
            GetViewControllers();

            var left = new UISideMenuNavigationController(sideMenuManager, leftSideController, leftSide: true);
            left.NavigationBarHidden = true;
            sideMenuManager.LeftNavigationController = left;
            sideMenuManager.RightNavigationController = new UISideMenuNavigationController(sideMenuManager, rightSideController, leftSide: false);

            // Enable gestures. The left and/or right menus must be set up above for these to work.
            // Note that these continue to work on the Navigation Controller independent of the View Controller it displays!
            sideMenuManager.AddPanGestureToPresent(toView: this.NavigationController?.NavigationBar);

            sideMenuManager.AddScreenEdgePanGesturesToPresent(toView: this.NavigationController?.View);

        }

        private void GetViewControllers()
        {
            leftSideController = Storyboard.InstantiateViewController("LeftViewCOntroller_ID") as LeftViewCOntroller;
            rightSideController = Storyboard.InstantiateViewController("RightViewController_ID") as RightViewController;
        }


        void SetDefaults()
        {
            //sideMenuManager.BlurEffectStyle = null;
            //sideMenuManager.AnimationFadeStrength = 5d;
            //sideMenuManager.ShadowOpacity = 5d;
            //sideMenuManager.AnimationTransformScaleFactor = 5d;
            //sideMenuManager.FadeStatusBar = true;
        }
    }
}