using Foundation;
using System;
using UIKit;

namespace SideMenu
{
    public partial class LeftViewCOntroller : UIViewController
    {
        public LeftViewCOntroller(IntPtr handle) : base(handle)
        {
        }
        public LeftViewCOntroller()
        {
            this.NavigationController.NavigationItem.TitleView.Hidden = true;
        }
    }
}