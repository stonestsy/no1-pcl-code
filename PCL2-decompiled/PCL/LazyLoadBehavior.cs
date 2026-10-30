using System;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace PCL;

public class LazyLoadBehavior
{
    private static readonly DependencyProperty IsInViewportProperty = DependencyProperty.RegisterAttached("IsInViewport", typeof(Action), typeof(LazyLoadBehavior), new PropertyMetadata(null, OnIsInViewportChanged));

    public static void OnFirstEnterScrollViewerViewport(DependencyObject obj, Action value)
    {
        obj.SetValue(IsInViewportProperty, value);
    }

    private static void OnIsInViewportChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        FrameworkElement frameworkElement = d as FrameworkElement;
        if (frameworkElement == null || e.NewValue == null)
        {
            return;
        }
        bool flag = false;
        EventHandler value = null;
        value = (object a0, System.EventArgs a1) =>
    {
        if (!flag && !(frameworkElement.RenderSize.Width < double.Epsilon) && frameworkElement.IsVisible)
        {
            ScrollViewer scrollViewer = FindParentScrollViewer(frameworkElement);
            if (scrollViewer != null && new Rect(0.0, 0.0, scrollViewer.ViewportWidth, scrollViewer.ViewportHeight).IntersectsWith(frameworkElement.TransformToAncestor(scrollViewer).TransformBounds(new Rect(new Point(0.0, 0.0), frameworkElement.RenderSize))))
            {
                flag = true;
                ((Action)e.NewValue)();
                frameworkElement.LayoutUpdated -= value;
            }
        }
    };
        frameworkElement.LayoutUpdated += value;
    }

    private static ScrollViewer FindParentScrollViewer(DependencyObject d)
    {
        while (d != null)
        {
            if (d is ScrollViewer)
            {
                return (ScrollViewer)d;
            }
            d = VisualTreeHelper.GetParent(d);
        }
        return null;
    }
}
