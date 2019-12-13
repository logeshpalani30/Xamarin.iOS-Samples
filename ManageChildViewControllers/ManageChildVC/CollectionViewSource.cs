using System;
using System.Collections.Generic;
using CoreGraphics;
using Foundation;
using UIKit;

namespace ManageChildVC
{
    public class CollectionViewSource : UICollectionViewSource
    {
        private List<string> titles;
        public static int selectedIndex;

        public CollectionViewSource(List<string> titles, int Index)
        {
            this.titles = titles;
            selectedIndex = Index;
        }
        public override UICollectionViewCell GetCell(UICollectionView collectionView, NSIndexPath indexPath)
        {
            var cell = collectionView.DequeueReusableCell("TabCollectionViewCell", indexPath) as TabCollectionViewCell;

            if (indexPath.Row == selectedIndex)
                cell.UpdateCell(this.titles[indexPath.Row], true);
            else
                cell.UpdateCell(this.titles[indexPath.Row], false);

            return cell;
        }
        public override nint GetItemsCount(UICollectionView collectionView, nint section)
        {
            return titles.Count;
        }
    }
    public class CollectionViewSourceDelegate : UICollectionViewDelegateFlowLayout
    {
        int listCount;
        ITab iTab;
        public CollectionViewSourceDelegate(int count, ITab iTab)
        {
            this.listCount = count;
            this.iTab = iTab;
        }
        public override nfloat GetMinimumInteritemSpacingForSection(UICollectionView collectionView, UICollectionViewLayout layout, nint section)
        {
            return 0;
        }
        public override CGSize GetSizeForItem(UICollectionView collectionView, UICollectionViewLayout layout, NSIndexPath indexPath)
        {
            var size = new CGSize();
            size.Width = collectionView.Frame.Width / 2;
            size.Height = collectionView.Frame.Height;
            return size;
        }
        public override void ItemSelected(UICollectionView collectionView, NSIndexPath indexPath)
        {
            iTab.OnTabChange(indexPath.Row);
            CollectionViewSource.selectedIndex = indexPath.Row;
            collectionView.ReloadData();
        }
    }
}
