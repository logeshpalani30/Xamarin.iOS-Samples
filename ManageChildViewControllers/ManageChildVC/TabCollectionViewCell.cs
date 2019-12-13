using System;

using Foundation;
using UIKit;

namespace ManageChildVC
{
    public partial class TabCollectionViewCell : UICollectionViewCell
    {
        public static readonly NSString Key = new NSString("TabCollectionViewCell");
        public static readonly UINib Nib;

        static TabCollectionViewCell()
        {
            Nib = UINib.FromName("TabCollectionViewCell", NSBundle.MainBundle);
        }

        protected TabCollectionViewCell(IntPtr handle) : base(handle)
        {
            // Note: this .ctor should not contain any initialization logic.

        }

        internal void UpdateCell(string title, bool visible)
        {
            titleLabel.Text = title;
            titleLabel.TextColor = UIColor.White;

            if (visible)
                indicatorline.Hidden = false;
            else
                indicatorline.Hidden = true;
        }
    }
}
