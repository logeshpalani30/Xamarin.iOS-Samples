using System;
using System.Collections.Generic;
using CoreGraphics;
using Foundation;
using UIKit;

namespace TableViewDemo
{
    public partial class ViewController : UIViewController
    {
        class TableViewSimpleSource : UITableViewSource
        {
            private List<string> listItems = new List<string>() { "List Item", "List Item", "List Item", "List Item", "List Item", "List Item", "List Item", "List Item", "List Item", "List Item", "List Item", "List Item", "List Item", "List Item", "List Item", "List Item" };

            public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
            {
                var cell = new UITableViewCell(CGRect.Empty);
                cell.TextLabel.Text = listItems[indexPath.Row];
                return cell;
            }

            public override nint RowsInSection(UITableView tableview, nint section)
            {
                return listItems.Count;
            }
        }

        public ViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            tableviewId.Source = new TableViewSimpleSource();
            // Perform any additional setup after loading the view, typically from a nib.
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}