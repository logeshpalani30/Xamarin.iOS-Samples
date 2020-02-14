using System;

using Foundation;
using UIKit;

namespace CustomTableViewCell
{
    public partial class MyCardViewCell : UITableViewCell
    {
        public static readonly NSString Key = new NSString("MyCardViewCell");
        public static readonly UINib Nib;

        static MyCardViewCell()
        {
            Nib = UINib.FromName("MyCardViewCell", NSBundle.MainBundle);
        }

        protected MyCardViewCell(IntPtr handle) : base(handle)
        {
            // Note: this .ctor should not contain any initialization logic.
        }
        public void UpdateData(string text)
        {
            title.Text = text;
        }
    }
}
