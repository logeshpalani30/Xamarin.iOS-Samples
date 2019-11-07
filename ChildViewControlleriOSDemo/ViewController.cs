using System;
using CoreGraphics;
using Metal;
using UIKit;

namespace ChildViewControlleriOSDemo
{
    public partial class ViewController : UIViewController
    {
        BookingsViewController bookingsViewController;
        StatisticsViewController statisticsViewController;

        public ViewController(IntPtr handle) : base(handle)
        {

        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            btnStatistics.TouchUpInside += BtnStatistics_TouchUpInside;
            btnBookings.TouchUpInside += BtnBookings_TouchUpInside;

            SetupChildViewControllers();
            //BooksViewControllerMathod();
            //StatisticsViewControllerMathod();
            LoadChildView(0);
            //Perform any additional setup after loading the view, typically from a nib.
        }

        private void SetupChildViewControllers()
        {
            AddViewControllerAsChildViewController(BooksViewControllerMathod());
            AddViewControllerAsChildViewController(StatisticsViewControllerMathod());
            //BooksViewControllerMathod();
            //StatisticsViewControllerMathod();
        }

        public UIViewController BooksViewControllerMathod()
        {
            bookingsViewController = this.Storyboard.InstantiateViewController("BookingsViewController") as BookingsViewController;
            this.AddChildViewController(bookingsViewController);
            return bookingsViewController;
        }

        public UIViewController StatisticsViewControllerMathod()
        {
            statisticsViewController = this.Storyboard.InstantiateViewController("StatisticsViewController") as StatisticsViewController;
            this.AddChildViewController(statisticsViewController);
            return statisticsViewController;
        }

        private void BtnBookings_TouchUpInside(object sender, EventArgs e)
        {
            LoadChildView(0);
        }

        private void LoadChildView(int v)
        {
            if (v == 0)
            {
                bookingsViewController.View.Hidden = false;
                statisticsViewController.View.Hidden = true;
            }
            else if (v == 1)
            {
                bookingsViewController.View.Hidden = true;
                statisticsViewController.View.Hidden = false;
            }
        }

        private void BtnStatistics_TouchUpInside(object sender, EventArgs e)
        {
            LoadChildView(1);
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }

        public void AddViewControllerAsChildViewController(UIViewController uIViewController)
        {
            this.AddChildViewController(uIViewController);
            View.AddSubview(uIViewController.View);
            uIViewController.View.Frame = new CGRect(0, 0, this.View.Frame.Width, this.View.Frame.Height - 50);
            uIViewController.View.AutoresizingMask = UIViewAutoresizing.FlexibleHeight;
            uIViewController.View.AutoresizingMask = UIViewAutoresizing.FlexibleWidth;


            //uIViewController.View.TranslatesAutoresizingMaskIntoConstraints = false;
            //uIViewController.View.TopAnchor.ConstraintEqualTo(View.TopAnchor, 0).Active = true;
            //uIViewController.View.LeftAnchor.ConstraintEqualTo(View.LeftAnchor, 0).Active = true;
            uIViewController.DidMoveToParentViewController(this);
            uIViewController.View.Hidden = true;
            //uIViewController.View.Hidden = true;
        }
    }
}