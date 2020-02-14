using System;
using Foundation;
using UIKit;

namespace CustomTableViewCell
{
    public class MyTableViewSource : UITableViewSource
    {
        private string[] titles;
        private INavigator navigator;

        public MyTableViewSource(INavigator navigator, params string[] titles)
        {
            this.titles = titles;
            this.navigator = navigator;
        }

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            var cell = tableView.DequeueReusableCell("MyCardViewCell_ID", indexPath) as MyCardViewCell;
            cell.UpdateData(titles[indexPath.Row]);

            return cell;

        }

        public override nint RowsInSection(UITableView tableview, nint section)
        {
            return titles.Length;
        }
        public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
        {
            base.RowSelected(tableView, indexPath);
            navigator.Navigate(indexPath.Row);
        }
    }
}
