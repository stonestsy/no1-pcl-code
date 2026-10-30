using System;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Shapes;
using MeloongCore;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace PCL;

[DesignerGenerated]
public partial class MyExtraButton : Grid, IComponentConnector
{
    public delegate void ClickEventHandler(object sender, MouseButtonEventArgs e);

    public delegate void RightClickEventHandler(object sender, MouseButtonEventArgs e);

    public delegate bool ShowCheckDelegate();

    private double _Progress;

    public int Uuid;

    private string _Logo;

    private double _LogoScale;

    private bool _Show;

    public ShowCheckDelegate ShowCheck;

    private bool _CanRightClick;

    private bool IsLeftMouseHeld;

    private bool IsRightMouseHeld;

    private const int AnimationColorIn = 120;

    private const int AnimationColorOut = 150;

    [CompilerGenerated]
    [AccessedThroughProperty("PanBack")]
    private MyExtraButton _PanBack;

    [CompilerGenerated]
    [AccessedThroughProperty("PanClick")]
    private Border _PanClick;

    [CompilerGenerated]
    [AccessedThroughProperty("PanScale")]
    private Grid _PanScale;

    [CompilerGenerated]
    [AccessedThroughProperty("PanColor")]
    private Border _PanColor;

    [CompilerGenerated]
    [AccessedThroughProperty("PanProgress")]
    private Border _PanProgress;

    [CompilerGenerated]
    [AccessedThroughProperty("RectProgress")]
    private RectangleGeometry _RectProgress;

    [CompilerGenerated]
    [AccessedThroughProperty("Path")]
    private Path _Path;

    public double Progress
    {
        get
        {
            return _Progress;
        }
        set
        {
            if (_Progress != value)
            {
                _Progress = value;
                if (value < 0.0001)
                {
                    PanProgress.Visibility = Visibility.Collapsed;
                    return;
                }
                PanProgress.Visibility = Visibility.Visible;
                RectProgress.Rect = new Rect(0.0, 40.0 * (1.0 - value), 40.0, 40.0 * value);
            }
        }
    }

    public string Logo
    {
        get
        {
            return _Logo;
        }
        set
        {
            if (Operators.CompareString(value, _Logo, TextCompare: false) != 0)
            {
                _Logo = value;
                Path.Data = (Geometry)new GeometryConverter().ConvertFromString(value);
            }
        }
    }

    public double LogoScale
    {
        get
        {
            return _LogoScale;
        }
        set
        {
            _LogoScale = value;
            if (!Information.IsNothing(Path))
            {
                Path.RenderTransform = new ScaleTransform
                {
                    ScaleX = LogoScale,
                    ScaleY = LogoScale
                };
            }
        }
    }

    public bool Show
    {
        get
        {
            return _Show;
        }
        set
        {
            if (_Show == value)
            {
                return;
            }
            _Show = value;
            ModBase.RunInUi(() =>
            {
                if (value)
                {
                    Visibility = Visibility.Visible;
                    ModAnimation.AniStart(new ModAnimation.AniData[3]
                    {
                        ModAnimation.AaScaleTransform(this, 0.3 - ((ScaleTransform)RenderTransform).ScaleX, 500, 60, new ModAnimation.AniEaseOutFluent(ModAnimation.AniEasePower.Weak)),
                        ModAnimation.AaScaleTransform(this, 0.7, 500, 60, new ModAnimation.AniEaseOutBack(ModAnimation.AniEasePower.Weak)),
                        ModAnimation.AaHeight(this, 50.0 - Height, 200, 0, new ModAnimation.AniEaseOutFluent(ModAnimation.AniEasePower.Weak))
                    }, "MyExtraButton MainScale " + Conversions.ToString(Uuid));
                }
                else
                {
                    ModAnimation.AniStart(new ModAnimation.AniData[3]
                    {
                        ModAnimation.AaScaleTransform(this, 0.0 - ((ScaleTransform)RenderTransform).ScaleX, 100, 0, new ModAnimation.AniEaseInFluent(ModAnimation.AniEasePower.Weak)),
                        ModAnimation.AaHeight(this, 0.0 - Height, 400, 100, new ModAnimation.AniEaseOutFluent()),
                        ModAnimation.AaCode(() =>
                        {
                            Visibility = Visibility.Collapsed;
                        }, 0, After: true)
                    }, "MyExtraButton MainScale " + Conversions.ToString(Uuid));
                }
                IsHitTestVisible = value;
            });
        }
    }

    public bool CanRightClick
    {
        get
        {
            return _CanRightClick;
        }
        set
        {
            _CanRightClick = value;
        }
    }

    internal virtual MyExtraButton PanBack_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _PanBack;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            _PanBack = value;
        }
    }

    internal virtual Border PanClick_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _PanClick;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            MouseButtonEventHandler value2 = Button_LeftMouseUp;
            MouseButtonEventHandler value3 = Button_RightMouseUp;
            MouseButtonEventHandler value4 = Button_LeftMouseDown;
            MouseButtonEventHandler value5 = Button_RightMouseDown;
            MouseButtonEventHandler value6 = (object a0, MouseButtonEventArgs a1) =>
            {
                Button_LeftMouseUp();
            };
            MouseButtonEventHandler value7 = (object a0, MouseButtonEventArgs a1) =>
            {
                Button_RightMouseUp();
            };
            MouseEventHandler value8 = (object a0, MouseEventArgs a1) =>
            {
                Button_MouseLeave();
            };
            MouseEventHandler value9 = (object a0, MouseEventArgs a1) =>
            {
                RefreshColor();
            };
            MouseEventHandler value10 = (object a0, MouseEventArgs a1) =>
            {
                RefreshColor();
            };
            Border border = _PanClick;
            if (border != null)
            {
                border.MouseLeftButtonUp -= value2;
                border.MouseRightButtonUp -= value3;
                border.MouseLeftButtonDown -= value4;
                border.MouseRightButtonDown -= value5;
                border.MouseLeftButtonUp -= value6;
                border.MouseRightButtonUp -= value7;
                border.MouseLeave -= value8;
                border.MouseEnter -= value9;
                border.MouseLeave -= value10;
            }
            _PanClick = value;
            border = _PanClick;
            if (border != null)
            {
                border.MouseLeftButtonUp += value2;
                border.MouseRightButtonUp += value3;
                border.MouseLeftButtonDown += value4;
                border.MouseRightButtonDown += value5;
                border.MouseLeftButtonUp += value6;
                border.MouseRightButtonUp += value7;
                border.MouseLeave += value8;
                border.MouseEnter += value9;
                border.MouseLeave += value10;
            }
        }
    }

    internal virtual Grid PanScale_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _PanScale;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            _PanScale = value;
        }
    }

    internal virtual Border PanColor_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _PanColor;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            _PanColor = value;
        }
    }

    internal virtual Border PanProgress_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _PanProgress;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            _PanProgress = value;
        }
    }

    internal virtual RectangleGeometry RectProgress_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _RectProgress;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            _RectProgress = value;
        }
    }

    internal virtual Path Path_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _Path;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            _Path = value;
        }
    }

    public event ClickEventHandler Click;

    public event RightClickEventHandler RightClick;

    public MyExtraButton()
    {
        Loaded += (object a0, RoutedEventArgs a1) =>
        {
            RefreshColor();
        };
        IsEnabledChanged += (object a0, DependencyPropertyChangedEventArgs a1) =>
        {
            RefreshColor();
        };
        _Progress = 0.0;
        Uuid = ModBase.GetUuid();
        _Logo = "";
        _LogoScale = 1.0;
        _Show = false;
        ShowCheck = null;
        _CanRightClick = false;
        IsLeftMouseHeld = false;
        IsRightMouseHeld = false;
        InitializeComponent();
        _InitWithEvents();
    }

    public void ShowRefresh()
    {
        if (ShowCheck != null)
        {
            Show = ShowCheck();
        }
    }

    private void Button_LeftMouseUp(object sender, MouseButtonEventArgs e)
    {
        if (IsLeftMouseHeld)
        {
            Logger.Info(string.Format("按下附加按钮{0}", RuntimeHelpers.GetObjectValue(Operators.ConditionalCompareObjectEqual(ToolTip, "", TextCompare: false) ? "" : Operators.ConcatenateObject("：", ToolTip))), (LogBehavior)0, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Controls\\MyExtraButton.xaml.vb");
            Click?.Invoke(RuntimeHelpers.GetObjectValue(sender), e);
            e.Handled = true;
            Button_LeftMouseUp();
        }
    }

    private void Button_RightMouseUp(object sender, MouseButtonEventArgs e)
    {
        if (IsRightMouseHeld)
        {
            Logger.Info(string.Format("右键按下附加按钮{0}", RuntimeHelpers.GetObjectValue(Operators.ConditionalCompareObjectEqual(ToolTip, "", TextCompare: false) ? "" : Operators.ConcatenateObject("：", ToolTip))), (LogBehavior)0, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Controls\\MyExtraButton.xaml.vb");
            RightClick?.Invoke(RuntimeHelpers.GetObjectValue(sender), e);
            e.Handled = true;
            Button_RightMouseUp();
        }
    }

    private void Button_LeftMouseDown(object sender, MouseButtonEventArgs e)
    {
        if (!IsLeftMouseHeld && !IsRightMouseHeld)
        {
            ModAnimation.AniStart(new ModAnimation.AniData[2]
            {
                ModAnimation.AaScaleTransform(PanScale, 0.85 - ((ScaleTransform)PanScale.RenderTransform).ScaleX, 800, 0, new ModAnimation.AniEaseOutFluent(ModAnimation.AniEasePower.Strong)),
                ModAnimation.AaScaleTransform(PanScale, -0.05, 60, 0, new ModAnimation.AniEaseOutFluent())
            }, "MyExtraButton Scale " + Conversions.ToString(Uuid));
        }
        IsLeftMouseHeld = true;
        Focus();
    }

    private void Button_RightMouseDown(object sender, MouseButtonEventArgs e)
    {
        if (CanRightClick)
        {
            if (!IsLeftMouseHeld && !IsRightMouseHeld)
            {
                ModAnimation.AniStart(new ModAnimation.AniData[2]
                {
                    ModAnimation.AaScaleTransform(PanScale, 0.85 - ((ScaleTransform)PanScale.RenderTransform).ScaleX, 800, 0, new ModAnimation.AniEaseOutFluent(ModAnimation.AniEasePower.Strong)),
                    ModAnimation.AaScaleTransform(PanScale, -0.05, 60, 0, new ModAnimation.AniEaseOutFluent())
                }, "MyExtraButton Scale " + Conversions.ToString(Uuid));
            }
            IsRightMouseHeld = true;
            Focus();
        }
    }

    private void Button_LeftMouseUp()
    {
        if (!IsRightMouseHeld)
        {
            ModAnimation.AniStart(new ModAnimation.AniData[1] { ModAnimation.AaScaleTransform(PanScale, 1.0 - ((ScaleTransform)PanScale.RenderTransform).ScaleX, 300, 0, new ModAnimation.AniEaseOutBack()) }, "MyExtraButton Scale " + Conversions.ToString(Uuid));
        }
        if (IsLeftMouseHeld)
        {
            ModMain.RaiseCustomEvent(this);
        }
        IsLeftMouseHeld = false;
        RefreshColor();
    }

    private void Button_RightMouseUp()
    {
        if (CanRightClick)
        {
            if (!IsLeftMouseHeld)
            {
                ModAnimation.AniStart(new ModAnimation.AniData[1] { ModAnimation.AaScaleTransform(PanScale, 1.0 - ((ScaleTransform)PanScale.RenderTransform).ScaleX, 300, 0, new ModAnimation.AniEaseOutBack()) }, "MyExtraButton Scale " + Conversions.ToString(Uuid));
            }
            IsRightMouseHeld = false;
            RefreshColor();
        }
    }

    private void Button_MouseLeave()
    {
        IsLeftMouseHeld = false;
        IsRightMouseHeld = false;
        ModAnimation.AniStart(new ModAnimation.AniData[1] { ModAnimation.AaScaleTransform(PanScale, 1.0 - ((ScaleTransform)PanScale.RenderTransform).ScaleX, 500, 0, new ModAnimation.AniEaseOutFluent()) }, "MyExtraButton Scale " + Conversions.ToString(Uuid));
        RefreshColor();
    }

    public void RefreshColor()
    {
        try
        {
            if (IsLoaded && ModAnimation.AniControlEnabled == 0)
            {
                if (!IsEnabled)
                {
                    ModAnimation.AniStart(ModAnimation.AaColor(PanColor, Panel.BackgroundProperty, "ColorBrushGray4", 120), "MyExtraButton Color " + Conversions.ToString(Uuid));
                }
                else if (IsMouseOver)
                {
                    ModAnimation.AniStart(ModAnimation.AaColor(PanColor, Panel.BackgroundProperty, "ColorBrush4", 120), "MyExtraButton Color " + Conversions.ToString(Uuid));
                }
                else
                {
                    ModAnimation.AniStart(ModAnimation.AaColor(PanColor, Panel.BackgroundProperty, "ColorBrush3", 150), "MyExtraButton Color " + Conversions.ToString(Uuid));
                }
                return;
            }
            ModAnimation.AniStop("MyExtraButton Color " + Conversions.ToString(Uuid));
            if (!IsEnabled)
            {
                PanColor.SetResourceReference(Panel.BackgroundProperty, "ColorBrushGray4");
            }
            else if (IsMouseOver)
            {
                PanColor.SetResourceReference(Panel.BackgroundProperty, "ColorBrush4");
            }
            else
            {
                PanColor.SetResourceReference(Panel.BackgroundProperty, "ColorBrush3");
            }
        }
        catch (Exception ex)
        {
            ProjectData.SetProjectError(ex);
            Exception ex2 = ex;
            Logger.Warn(ex2, "刷新图标按钮颜色出错", (LogBehavior)1, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Controls\\MyExtraButton.xaml.vb");
            ProjectData.ClearProjectError();
        }
    }

    public void Ribble()
    {
        ModBase.RunInUi(() =>
        {
            Border border = new Border
            {
                CornerRadius = new CornerRadius(1000.0),
                BorderThickness = new Thickness(0.001),
                Opacity = 0.5,
                RenderTransformOrigin = new Point(0.5, 0.5),
                RenderTransform = new ScaleTransform()
            };
            border.SetResourceReference(Border.BackgroundProperty, "ColorBrush5");
            PanScale.Children.Insert(0, border);
            ModAnimation.AniStart(new ModAnimation.AniData[3]
            {
                ModAnimation.AaScaleTransform(border, 13.0, 1000, 0, new ModAnimation.AniEaseInoutFluent(ModAnimation.AniEasePower.Strong, 0.3)),
                ModAnimation.AaOpacity(border, 0.0 - border.Opacity, 1000),
                ModAnimation.AaCode(() =>
                {
                    PanScale.Children.Remove(border);
                }, 0, After: true)
            }, "ExtraButton Ribble " + Conversions.ToString(ModBase.GetUuid()));
        });
    }

    private bool _withEventsInitialized;
    private void _InitWithEvents()
    {
        if (_withEventsInitialized) { return; }
        _withEventsInitialized = true;
        PanBack_WithEvents = PanBack;
        PanClick_WithEvents = PanClick;
        PanColor_WithEvents = PanColor;
        PanProgress_WithEvents = PanProgress;
        PanScale_WithEvents = PanScale;
        Path_WithEvents = Path;
        RectProgress_WithEvents = RectProgress;
    }
}
