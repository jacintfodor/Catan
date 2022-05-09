using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

namespace Catan.View_Rework
{
    internal class RelativeCanvas : Canvas
    {
        public static readonly DependencyProperty XRatioProperty =
        DependencyProperty.RegisterAttached(
          "XRatio",
          typeof(double),
          typeof(RelativeCanvas),
          new FrameworkPropertyMetadata(defaultValue: 0.0,
              flags: FrameworkPropertyMetadataOptions.AffectsRender)
        );

        // Declare a get accessor method.
        public static double GetXRatio(UIElement target) =>
            (double)target.GetValue(XRatioProperty);

        // Declare a set accessor method.
        public static void SetXRatio(UIElement target, double value) =>
            target.SetValue(XRatioProperty, value);

        public static readonly DependencyProperty YRatioProperty =
            DependencyProperty.RegisterAttached(
              "YRatio",
              typeof(double),
              typeof(RelativeCanvas),
              new FrameworkPropertyMetadata(defaultValue: 0.0,
                  flags: FrameworkPropertyMetadataOptions.AffectsRender)
            );

        // Declare a get accessor method.
        public static double GetYRatio(UIElement target) =>
            (double)target.GetValue(YRatioProperty);

        // Declare a set accessor method.
        public static void SetYRatio(UIElement target, double value) =>
            target.SetValue(YRatioProperty, value);

        protected override Size ArrangeOverride(Size arrangeSize)
        {
            foreach (UIElement child in Children)
            {
                double x = this.ActualWidth * GetXRatio(child);
                double y = this.ActualHeight * GetYRatio(child);
                
                SetLeft(child, x);
                SetTop(child, y);
            }
            return base.ArrangeOverride(arrangeSize);
            // real Canvas has more sophisticated sizing
        }

    }
}
