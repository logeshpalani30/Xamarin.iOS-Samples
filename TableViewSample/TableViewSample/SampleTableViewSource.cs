using System;
using System.Collections.Generic;
using CoreGraphics;
using Foundation;
using UIKit;

namespace TableViewSample
{
    internal class SampleTableViewSource : UITableViewSource
    {
        private IList<ContactModel> data;
        public SampleTableViewSource(List<ContactModel> data)
        {
            this.data = data;
        }

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            var cell = new UITableViewCell(UITableViewCellStyle.Default, null);
            var dataSet = data[indexPath.Row];

            if (dataSet != null)
            {
                cell.TextLabel.Text = dataSet.Name;
                cell.ImageView.Image = UIImage.FromBundle("Phineas_Flynn");
                //cell.DetailTextLabel.Text = dataSet.MobileNumber;
            }

            return cell;
        }

        public override nint RowsInSection(UITableView tableview, nint section)
        {
            return data.Count;
        }
    }
}