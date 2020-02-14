using System;
using UIKit;

namespace CustomTableViewCell
{
    public partial class ViewController : UIViewController, INavigator
    {
        public ViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.

            tableView.RegisterNibForCellReuse(MyCardViewCell.Nib, "MyCardViewCell_ID");
            tableView.Source = new MyTableViewSource(this, "Remainder", "Remainder 1", "Remainder 22", "Remainder 3", "Remainder 55", "Remainder 66");

            tableView.RowHeight = UITableView.AutomaticDimension;
            tableView.ReloadData();
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }

        public void Navigate(int index)
        {
            // Do Navigation code 
        }
    }
}