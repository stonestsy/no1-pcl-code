using System;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Shapes;
using MeloongCore;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace PCL;

[DesignerGenerated]
public partial class MySlider : Border, ISettingControl, IComponentConnector
{
    public delegate void ChangeEventHandler(object sender, bool user);

    public delegate void PreviewChangeEventHandler(object sender, ModBase.RouteEventArgs e);

    public int Uuid;

    private int _MaxValue;

    private bool ChangeByKey;

    private int _Value;

    public Delegate GetHintText;

    [CompilerGenerated]
    [AccessedThroughProperty("PanBack")]
    private MySlider _PanBack;

    [CompilerGenerated]
    [AccessedThroughProperty("PanMain")]
    private Grid _PanMain;

    [CompilerGenerated]
    [AccessedThroughProperty("LineBack")]
    private Line _LineBack;

    [CompilerGenerated]
    [AccessedThroughProperty("LineFore")]
    private Line _LineFore;

    [CompilerGenerated]
    [AccessedThroughProperty("ShapeDot")]
    private Ellipse _ShapeDot;

    [CompilerGenerated]
    [AccessedThroughProperty("Popup")]
    private Popup _Popup;

    [CompilerGenerated]
    [AccessedThroughProperty("TextHint")]
    private TextBlock _TextHint;

    public int MaxValue
    {
        get
        {
            return _MaxValue;
        }
        set
        {
            if (value != _MaxValue)
            {
                _MaxValue = value;
                RefreshWidth(null, null);
            }
        }
    }

    public int Value
    {
        get
        {
            return _Value;
        }
        set
        {
            try
            {
                value = MathUtils.Clamp<int>(value, 0, MaxValue);
                if (_Value == value)
                {
                    return;
                }
                int value2 = _Value;
                _Value = value;
                if (ModAnimation.AniControlEnabled == 0)
                {
                    ModBase.RouteEventArgs e = new ModBase.RouteEventArgs();
                    PreviewChange?.Invoke(this, e);
                    if (e.Handled)
                    {
                        _Value = value2;
                        DragStop();
                        return;
                    }
                }
                if (IsLoaded && ModAnimation.AniControlEnabled == 0)
                {
                    if (ActualWidth < ShapeDot.Width)
                    {
                        return;
                    }
                    double num = (double)_Value / (double)MaxValue * (ActualWidth - ShapeDot.Width);
                    double num2 = Math.Abs(LineFore.Width / (ActualWidth - ShapeDot.Width) - (double)_Value / (double)MaxValue);
                    double num3 = (1.0 - Math.Pow(1.0 - num2, 3.0)) * 300.0 + (double)(ChangeByKey ? 100 : 0);
                    ModAnimation.AniStart(checked(new ModAnimation.AniData[3]
                    {
                        ModAnimation.AaWidth(LineFore, Math.Max(0.0, num + ((num < 0.5) ? 0.0 : 0.5)) - LineFore.Width, (int)Math.Round(num3), 0, (num3 > 50.0) ? ((ModAnimation.AniEase)new ModAnimation.AniEaseOutFluent()) : ((ModAnimation.AniEase)new ModAnimation.AniEaseLinear())),
                        ModAnimation.AaWidth(LineBack, Math.Max(0.0, ActualWidth - ShapeDot.Width - num + ((ActualWidth - ShapeDot.Width - num < 0.5) ? 0.0 : 0.5)) - LineBack.Width, (int)Math.Round(num3), 0, (num3 > 50.0) ? ((ModAnimation.AniEase)new ModAnimation.AniEaseOutFluent()) : ((ModAnimation.AniEase)new ModAnimation.AniEaseLinear())),
                        ModAnimation.AaX(ShapeDot, num - ShapeDot.Margin.Left, (int)Math.Round(num3), 0, (num3 > 50.0) ? ((ModAnimation.AniEase)new ModAnimation.AniEaseOutFluent()) : ((ModAnimation.AniEase)new ModAnimation.AniEaseLinear()))
                    }), "MySlider Progress " + Conversions.ToString(Uuid));
                }
                else
                {
                    RefreshWidth(null, null);
                }
                if (ModAnimation.AniControlEnabled == 0)
                {
                    Change?.Invoke(this, user: false);
                }
            }
            catch (Exception ex)
            {
                ProjectData.SetProjectError(ex);
                Exception ex2 = ex;
                Logger.Error(ex2, "滑动条进度改变出错", (LogBehavior)2, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Controls\\MySlider.xaml.vb");
                ProjectData.ClearProjectError();
            }
        }
    }

    public uint ValueByKey { get; set; }

    internal virtual MySlider PanBack_WithEvents
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

    internal virtual Grid PanMain_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _PanMain;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            _PanMain = value;
        }
    }

    internal virtual Line LineBack_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _LineBack;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            _LineBack = value;
        }
    }

    internal virtual Line LineFore_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _LineFore;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            _LineFore = value;
        }
    }

    internal virtual Ellipse ShapeDot_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _ShapeDot;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            _ShapeDot = value;
        }
    }

    internal virtual Popup Popup_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _Popup;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            _Popup = value;
        }
    }

    internal virtual TextBlock TextHint_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _TextHint;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            _TextHint = value;
        }
    }

    public event ChangeEventHandler Change;

    public event PreviewChangeEventHandler PreviewChange;

    public MySlider()
    {
        SizeChanged += RefreshWidth;
        MouseLeftButtonDown += DragStart;
        IsEnabledChanged += (object a0, DependencyPropertyChangedEventArgs a1) =>
        {
            RefreshColor();
        };
        MouseEnter += (object a0, MouseEventArgs a1) =>
        {
            RefreshColor();
        };
        MouseLeave += (object a0, MouseEventArgs a1) =>
        {
            RefreshColor();
        };
        MouseEnter += (object a0, MouseEventArgs a1) =>
        {
            MySlider_MouseEnter();
        };
        KeyDown += MySlider_KeyDown;
        Change += (object a0, bool a1) =>
        {
            SaveSetting();
        };
        Uuid = ModBase.GetUuid();
        _MaxValue = 100;
        ChangeByKey = false;
        _Value = 0;
        ValueByKey = 1u;
        InitializeComponent();
        _InitWithEvents();
    }

    private void RefreshWidth(object sender, SizeChangedEventArgs e)
    {
        if (!Information.IsNothing(e))
        {
            PanMain.Width = e.NewSize.Width;
        }
        ModAnimation.AniStop("MySlider Progress " + Conversions.ToString(Uuid));
        double num = (double)_Value / (double)MaxValue * (ActualWidth - ShapeDot.Width);
        LineFore.Width = Math.Max(0.0, num + ((num < 0.5) ? 0.0 : 0.5));
        LineBack.Width = Math.Max(0.0, ActualWidth - ShapeDot.Width - num + ((ActualWidth - ShapeDot.Width - num < 0.5) ? 0.0 : 0.5));
        ShapeDot.Margin = new Thickness(num, ShapeDot.Margin.Top, ShapeDot.Margin.Right, ShapeDot.Margin.Bottom);
    }

    private void DragStart(object sender, MouseButtonEventArgs e)
    {
        e.Handled = true;
        ModMain.DragControl = this;
        RefreshColor();
        ModMain.FrmMain.DragDoing();
        ModAnimation.AniStart(new ModAnimation.AniData[1] { ModAnimation.AaScaleTransform(ShapeDot, 1.3 - ((ScaleTransform)ShapeDot.RenderTransform).ScaleX, 40, 0, new ModAnimation.AniEaseOutFluent()) }, "MySlider Scale " + Conversions.ToString(Uuid));
        RefreshPopup();
        ModAnimation.AniStop("MySlider KeyPopup " + Conversions.ToString(Uuid));
    }

    public void DragDoing()
    {
        int num = checked((int)Math.Round(MathUtils.Clamp<double>((Mouse.GetPosition(PanMain).X - ShapeDot.Width / 2.0) / (ActualWidth - ShapeDot.Width), 0.0, 1.0) * (double)MaxValue));
        if (num != Value)
        {
            Value = num;
        }
        RefreshPopup();
    }

    public void DragStop()
    {
        RefreshColor();
        ModAnimation.AniStart(new ModAnimation.AniData[1] { ModAnimation.AaScaleTransform(ShapeDot, 1.0 - ((ScaleTransform)ShapeDot.RenderTransform).ScaleX, 200, 0, new ModAnimation.AniEaseOutFluent()) }, "MySlider Scale " + Conversions.ToString(Uuid));
        Popup.IsOpen = false;
    }

    public void RefreshPopup()
    {
        if ((object)GetHintText != null)
        {
            Popup.IsOpen = true;
            TextHint.Text = Conversions.ToString(GetHintText.DynamicInvoke(Value));
            Typeface typeface = new Typeface(TextHint.FontFamily, TextHint.FontStyle, TextHint.FontWeight, TextHint.FontStretch);
            FormattedText formattedText = new FormattedText(TextHint.Text, Thread.CurrentThread.CurrentCulture, TextHint.FlowDirection, typeface, TextHint.FontSize, TextHint.Foreground, ModBase.DPI);
            TextHint.Width = formattedText.Width;
        }
    }

    private void RefreshColor()
    {
        try
        {
            string text;
            string text2;
            int time;
            if (IsEnabled)
            {
                if (!Information.IsNothing(RuntimeHelpers.GetObjectValue(ModMain.DragControl)) && ModMain.DragControl.Equals(this))
                {
                    text = "ColorBrush3";
                    text2 = "ColorBrush3";
                    time = 40;
                }
                else if (IsMouseOver)
                {
                    text = "ColorBrush3";
                    text2 = "ColorBrush3";
                    time = 40;
                }
                else
                {
                    text = "ColorBrushBg0";
                    text2 = "ColorBrushBg0";
                    time = 100;
                }
            }
            else
            {
                text = "ColorBrushGray5";
                text2 = "ColorBrushGray5";
                time = 200;
            }
            if (IsLoaded && ModAnimation.AniControlEnabled == 0)
            {
                ModAnimation.AniStart(new ModAnimation.AniData[2]
                {
                    ModAnimation.AaColor(this, Border.BorderBrushProperty, text, time),
                    ModAnimation.AaColor(ShapeDot, Shape.FillProperty, text2, time)
                }, "MySlider Color " + Conversions.ToString(Uuid));
            }
            else
            {
                ModAnimation.AniStop("MySlider Color " + Conversions.ToString(Uuid));
                SetResourceReference(Border.BorderBrushProperty, text);
                ShapeDot.SetResourceReference(Shape.FillProperty, text2);
            }
        }
        catch (Exception ex)
        {
            ProjectData.SetProjectError(ex);
            Exception ex2 = ex;
            Logger.Warn(ex2, "滑动条颜色改变出错", (LogBehavior)1, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Controls\\MySlider.xaml.vb");
            ProjectData.ClearProjectError();
        }
    }

    private void MySlider_MouseEnter()
    {
        Focus();
    }

    private void MySlider_KeyDown(object sender, KeyEventArgs e)
    {
        if (object.ReferenceEquals(this, RuntimeHelpers.GetObjectValue(ModMain.DragControl)))
        {
            return;
        }
        checked
        {
            if (e.Key == Key.Left)
            {
                ChangeByKey = true;
                Value = (int)(Value - ValueByKey);
                ChangeByKey = false;
                e.Handled = true;
            }
            else
            {
                if (e.Key != Key.Right)
                {
                    return;
                }
                ChangeByKey = true;
                Value = (int)(Value + ValueByKey);
                ChangeByKey = false;
                e.Handled = true;
            }
            if ((object)GetHintText != null)
            {
                RefreshPopup();
                ModAnimation.AniStop("MySlider KeyPopup " + Conversions.ToString(Uuid));
                ModAnimation.AniStart(ModAnimation.AaCode(() =>
                {
                    Popup.IsOpen = false;
                }, (int)Math.Round(700.0 * ModAnimation.AniSpeed)), "MySlider KeyPopup " + Conversions.ToString(Uuid));
            }
        }
    }

    private void RefreshSetting(string NewValue)
    {
        Value = checked((int)Math.Round(ModBase.Val(NewValue)));
    }

    void ISettingControl.RefreshSetting(string NewValue)
    {
        this.RefreshSetting(NewValue);
    }

    private string GetCurrentSetting()
    {
        return Conversions.ToString(Value);
    }

    string ISettingControl.GetCurrentSetting()
    {
        return this.GetCurrentSetting();
    }

    private void SaveSetting()
    {
        SettingService.SaveSetting(this);
    }

    private bool _withEventsInitialized;
    private void _InitWithEvents()
    {
        if (_withEventsInitialized) { return; }
        _withEventsInitialized = true;
        LineBack_WithEvents = LineBack;
        LineFore_WithEvents = LineFore;
        PanBack_WithEvents = PanBack;
        PanMain_WithEvents = PanMain;
        Popup_WithEvents = Popup;
        ShapeDot_WithEvents = ShapeDot;
        TextHint_WithEvents = TextHint;
    }
}
