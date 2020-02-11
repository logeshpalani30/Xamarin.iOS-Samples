using System;
using System.Collections.ObjectModel;
using CoreGraphics;
using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;
using UIKit;

namespace chartsDemo
{
    public partial class ViewController : UIViewController
    {
        public ViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.

            var model = new PlotModel()
            {
                Title = "Column",
                PlotType = PlotType.XY,
                LegendSymbolLength = 5,
                LegendPlacement = LegendPlacement.Outside,
                LegendOrientation = LegendOrientation.Vertical,

            };


            CategoryAxis xaxis = new CategoryAxis();
            xaxis.Position = AxisPosition.Bottom;
            //xaxis.MajorGridlineStyle = LineStyle.Solid;
            //xaxis.MinorGridlineStyle = LineStyle.Dot;
            xaxis.Labels.Add("Mon, 4/24");
            xaxis.Labels.Add("Tue, 4/25");
            xaxis.Labels.Add("Wed, 4/26");
            xaxis.Labels.Add("Thu, 4/27");
            xaxis.Labels.Add("Mon, 4/24");
            xaxis.Labels.Add("Tue, 4/25");
            //xaxis.Labels.Add("Wed, 4/26");
            //xaxis.Labels.Add("Thu, 4/27");
            //xaxis.GapWidth = 20;
            xaxis.AbsoluteMinimum = -.5;
            xaxis.AbsoluteMaximum = 6;
            xaxis.Zoom(0, 4.5);
            xaxis.Angle = 45;


            LinearAxis yaxis = new LinearAxis();
            yaxis.Position = AxisPosition.Left;
            //yaxis.MajorGridlineStyle = LineStyle.Dot;
            //yaxis.MinorGridlineStyle = LineStyle.Dot;
            yaxis.AbsoluteMinimum = 0;
            yaxis.MinimumPadding = 0;
            yaxis.AbsoluteMaximum = 100;

            //LinearAxis xRightAxis = new LinearAxis();
            //yaxis.Position = AxisPosition.Right;
            //yaxis.AbsoluteMinimum = 0;

            ColumnSeries s1 = new ColumnSeries();
            s1.IsStacked = true;
            s1.Items.Add(new ColumnItem(20));
            s1.Items.Add(new ColumnItem(60));
            s1.Items.Add(new ColumnItem(40));
            s1.Items.Add(new ColumnItem(50));
            s1.Items.Add(new ColumnItem(20));
            s1.Items.Add(new ColumnItem(60));
            //s1.Items.Add(new ColumnItem(40));
            //s1.Items.Add(new ColumnItem(50));
            s1.ColumnWidth = 20;
            s1.FillColor = OxyColor.FromRgb(255, 0, 0);

            ColumnSeries s2 = new ColumnSeries();
            s2.IsStacked = true;
            s2.Items.Add(new ColumnItem(50));
            s2.Items.Add(new ColumnItem(30));
            s2.Items.Add(new ColumnItem(10));
            s2.Items.Add(new ColumnItem(20));
            s2.ColumnWidth = 20;

            //model.Axes.Add(xaxis);
            //model.Axes.Add(xaxis1);
            //model.Axes.Add(yaxis);
            //model.Axes.Add(xRightAxis);
            //model.Series.Add(s1);
            //model.Series.Add(s2);

            var Items = new Collection<Item>
            {
                new Item {Label = "Apples", Value1 = 37, Value2 = 12},
                new Item {Label = "Pears", Value1 = 7, Value2 = 21},
                new Item {Label = "Bananas", Value1 = 23, Value2 = 2}
            };

            model.Axes.Add(new CategoryAxis { ItemsSource = Items, LabelField = "Label", AbsoluteMinimum = -0.5 });
            model.Axes.Add(new LinearAxis { Position = AxisPosition.Left, MinimumPadding = 0, AbsoluteMinimum = 0 });
            model.Series.Add(new ColumnSeries { Title = "2009", ItemsSource = Items, ValueField = "Value1", ColumnWidth = 20 });
            model.Series.Add(new ColumnSeries { Title = "2010", ItemsSource = Items, ValueField = "Value2", ColumnWidth = 20 });
            model.Series.Add(new ColumnSeries { Title = "2011", ItemsSource = Items, ValueField = "Value3" });

            this.plotview.Model = model;
            plotview.Frame = new CGRect(0, 0, this.View.Frame.Width + 20, this.View.Frame.Height);

        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}
