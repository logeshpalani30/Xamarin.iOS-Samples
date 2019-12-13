using Foundation;
using System;
using System.Collections.Generic;
using UIKit;

namespace ManageChildVC
{
    public partial class ViewController : UIViewController, ITab
    {
        private FirstChildViewController firstController;
        private SecondChildViewController secondController;

        public ViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.

            var tabTitles = new List<string>() { "Tab 1 💝", "Tab 2 👨🏻‍💻" };

            SetUpChildViewControllers();

            collectionView.RegisterNibForCell(TabCollectionViewCell.Nib, "TabCollectionViewCell");
            collectionView.Source = new CollectionViewSource(tabTitles, 0);
            collectionView.Delegate = new CollectionViewSourceDelegate(tabTitles.Count, this);
            collectionView.ReloadData();

            LoadController(0);
        }

        private void SetUpChildViewControllers()
        {
            AddViewControllerAsChildViewController(FirstTabViewController());
            AddViewControllerAsChildViewController(SecondTabViewController());
        }
        public UIViewController FirstTabViewController()
        {
            firstController = this.Storyboard.InstantiateViewController("FirstChildViewController") as FirstChildViewController;
            return firstController;
        }
        public UIViewController SecondTabViewController()
        {
            secondController = this.Storyboard.InstantiateViewController("SecondChildViewController") as SecondChildViewController;
            return secondController;
        }

        private void AddViewControllerAsChildViewController(UIViewController viewController)
        {
            this.AddChildViewController(viewController);
            View.AddSubview(viewController.View);
            viewController.View.Frame = ViewControllerSpace.Frame;
            viewController.DidMoveToParentViewController(this);
            viewController.View.Hidden = true;
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }

        public void OnTabChange(int indexPath)
        {
            LoadController(indexPath);
        }

        private void LoadController(int indexPath)
        {
            collectionView.ReloadData();

            if (indexPath == 0)
            {
                firstController.View.Hidden = false;
                secondController.View.Hidden = true;
            }
            else if (indexPath == 1)
            {
                firstController.View.Hidden = true;
                secondController.View.Hidden = false;
            }
        }
    }
}